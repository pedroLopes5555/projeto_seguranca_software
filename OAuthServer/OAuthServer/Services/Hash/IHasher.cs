namespace OAuthServer.Services.Hash
{
    /// <summary>
    /// Interface for password hashing services.
    /// </summary>
    public interface IHasher
    {
        /// <summary>
        /// Hashes a plain-text string and returns the hashed value.
        /// </summary>
        /// <param name="text">The plain-text string to hash.</param>
        /// <returns>A base64 encoded string containing the salt and hash, separated by a delimiter.</returns>
        string GetStringHashed(string text);

        /// <summary>
        /// Verifies a string against a previously hashed string.
        /// </summary>
        /// <param name="textHashed">The stored string hash, including salt.</param>
        /// <param name="plainText">The plain-text to verify.</param>
        /// <returns>True if the text matches the hash; otherwise, false.</returns>
        bool VerifyText(string textHashed, string plainText);
    }
}