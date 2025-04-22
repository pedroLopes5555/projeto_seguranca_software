using System;
using Moq;
using NUnit.Framework;
using OAuthServer.Repository.Grant;
using OAuthServer.Services.GrantService;

namespace TestProject1
{
    [TestFixture]
    public class GrantServiceTests
    {
        private Mock<IGrantRepository> _mockGrantRepository;
        private GrantService _grantService;

        [SetUp]
        public void Setup()
        {
            _mockGrantRepository = new Mock<IGrantRepository>();
            _grantService = new GrantService(_mockGrantRepository.Object);
        }

        [Test]
        public void CreateGrant_ShouldReturnNewGuid_AndStoreIt()
        {
            // Act
            var grant = _grantService.CreateGrant();

            // Assert
            Assert.AreNotEqual(Guid.Empty, grant);
            _mockGrantRepository.Verify(r => r.AddGrant(grant), Times.Once);
        }

        [Test]
        public void CheckGrant_ShouldReturnFalse_WhenGrantNotFound()
        {
            // Arrange
            var grant = Guid.NewGuid();
            _mockGrantRepository.Setup(r => r.FindGrant(grant)).Returns((Guid?)null);

            // Act
            var result = _grantService.CheckGrant(grant);

            // Assert
            Assert.IsFalse(result);
            _mockGrantRepository.Verify(r => r.RemoveGrant(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public void CheckGrant_ShouldReturnTrue_WhenGrantExists_AndIsRemoved()
        {
            // Arrange
            var grant = Guid.NewGuid();
            _mockGrantRepository.Setup(r => r.FindGrant(grant)).Returns(grant);

            // Act
            var result = _grantService.CheckGrant(grant);

            // Assert
            Assert.IsTrue(result);
            _mockGrantRepository.Verify(r => r.RemoveGrant(grant), Times.Once);
        }

        [Test]
        public void CheckGrant_ShouldThrowException_WhenRemovalFails()
        {
            // Arrange
            var grant = Guid.NewGuid();
            _mockGrantRepository.Setup(r => r.FindGrant(grant)).Returns(grant);
            _mockGrantRepository.Setup(r => r.RemoveGrant(grant)).Throws(new Exception("DB error"));

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _grantService.CheckGrant(grant));
            Assert.That(ex.Message, Is.EqualTo("Could not remove grant"));
            Assert.That(ex.InnerException?.Message, Is.EqualTo("DB error"));
        }
    }
}
