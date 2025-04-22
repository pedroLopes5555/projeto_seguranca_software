using NUnit.Framework;
using OAuthServer.Services.Hash;

namespace OAuthTest;

[TestFixture]
public class HasherTests
{
    private IHasher _hasher;

    // Constructor-based injection
    public HasherTests()
    {
        _hasher = new Hasher();
    }

    [Test]
    public void GetStringHashed_ShouldReturnHashedString()
    {
        // Arrange
        string input = "examplePassword";

        // Act
        string hashed = _hasher.GetStringHashed(input);

        // Assert
        Assert.That(hashed, Is.Not.Null);
        Assert.That(hashed, Is.Not.Empty);
        Assert.That(hashed, Does.Contain(";"));
        Assert.That(hashed.Split(';').Length, Is.EqualTo(2));
    }

    [Test]
    public void VerifyText_ShouldReturnTrue_ForCorrectInput()
    {
        // Arrange
        string plainText = "mySecretText";
        string hashed = _hasher.GetStringHashed(plainText);

        // Act
        bool result = _hasher.VerifyText(hashed, plainText);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void VerifyText_ShouldReturnFalse_ForIncorrectInput()
    {
        // Arrange
        string originalText = "correctPassword";
        string wrongText = "wrongPassword";
        string hashed = _hasher.GetStringHashed(originalText);

        // Act
        bool result = _hasher.VerifyText(hashed, wrongText);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void VerifyText_ShouldThrowException_IfHashFormatIsInvalid()
    {
        // Arrange
        string invalidHash = "thisIsNotValidHash";

        // Act & Assert
        Assert.That(() => _hasher.VerifyText(invalidHash, "anyText"), 
            Throws.InstanceOf<System.FormatException>());
    }
}