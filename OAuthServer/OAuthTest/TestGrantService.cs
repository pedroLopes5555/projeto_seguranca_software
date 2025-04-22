using Moq;
using NUnit.Framework;
using OAuthServer.Repository.Grant;
using OAuthServer.Services.GrantService;
using System;

namespace OAuthTest
{
    [TestFixture]
    public class GrantServiceTests
    {
        private Mock<IGrantRepository> _grantRepositoryMock;
        private IGrantService _grantService;

        [SetUp]
        public void Setup()
        {
            _grantRepositoryMock = new Mock<IGrantRepository>();
            _grantService = new GrantService(_grantRepositoryMock.Object);
        }

        [Test]
        public void CreateGrant_ShouldReturnNewGuid_AndAddGrantToRepository()
        {
            // Arrange
            var newGrantId = Guid.NewGuid();

            // Act
            var result = _grantService.CreateGrant();

            // Assert
            _grantRepositoryMock.Verify(repo => repo.AddGrant(It.Is<Guid>(g => g == result)), Times.Once);
            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void CheckGrant_ShouldReturnTrue_AndRemoveGrant_WhenGrantExists()
        {
            // Arrange
            var grantId = Guid.NewGuid();
            _grantRepositoryMock.Setup(repo => repo.FindGrant(grantId)).Returns(grantId);

            // Act
            var result = _grantService.CheckGrant(grantId);

            // Assert
            Assert.That(result, Is.True);
            _grantRepositoryMock.Verify(repo => repo.RemoveGrant(grantId), Times.Once);
        }

        [Test]
        public void CheckGrant_ShouldReturnFalse_WhenGrantDoesNotExist()
        {
            // Arrange
            var grantId = Guid.NewGuid();
            _grantRepositoryMock.Setup(repo => repo.FindGrant(grantId)).Returns((Guid?)null);

            // Act
            var result = _grantService.CheckGrant(grantId);

            // Assert
            Assert.That(result, Is.False);
            _grantRepositoryMock.Verify(repo => repo.RemoveGrant(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public void CheckGrant_ShouldThrowException_WhenRemoveFails()
        {
            // Arrange
            var grantId = Guid.NewGuid();
            _grantRepositoryMock.Setup(repo => repo.FindGrant(grantId)).Returns(grantId);
            _grantRepositoryMock.Setup(repo => repo.RemoveGrant(grantId)).Throws<Exception>();

            // Act & Assert
            Assert.That(() => _grantService.CheckGrant(grantId), 
                        Throws.Exception.With.Message.Contains("Could not remove grant"));
        }
    }
}
