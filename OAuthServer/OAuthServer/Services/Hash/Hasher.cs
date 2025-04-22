using System.Security.Cryptography;

namespace OAuthServer.Services.Hash;

public class Hasher : IHasher
{
    
    private const int SaltSize = 128 / 8;
    private const int KeySize = 512 / 8;
    private const int Iterations = 1000;
    private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA512;
    private const char Delimiter = ';';
    

    //method to ashe the string
    public string GetStringHashed(string text)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(text, salt, Iterations, HashAlgorithmName, KeySize);

        return String.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool VerifyText(string textHashed, string plainText)
    {
        var elements = textHashed.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashResult = Rfc2898DeriveBytes.Pbkdf2(plainText, salt, Iterations, HashAlgorithmName, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashResult);
    }
    
}