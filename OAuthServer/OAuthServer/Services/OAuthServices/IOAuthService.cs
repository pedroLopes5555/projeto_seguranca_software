namespace OAuthServer.Services.OAuthServices
{
    /// <summary>
    /// Service interface for managing server security.
    /// </summary>
    public interface IOAuthService
    {
        /// <summary>
        /// Grants authorization to a client application.
        /// </summary>
        /// <param name="responseType">The Authorization Code Flow, should be "code".</param>
        /// <param name="clientId">The client application's id.</param>
        /// <param name="redirectUri">Where to send the user after approving.</param>
        /// <param name="scope">What permissions are requested.</param>
        /// <param name="state">Random value to protect against CSRF</param>
        /// <returns>The redirect URL of the client, with the code.</returns>
        Task<String> AuthorizeAsync(
            string responseType, 
            Guid clientId,
            string redirectUri,
            string scope,
            string state
        );
    }
}
