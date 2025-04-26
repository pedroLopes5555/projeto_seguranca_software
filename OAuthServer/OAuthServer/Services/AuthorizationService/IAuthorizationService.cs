namespace OAuthServer.Services.AuthorizationService
{
    /// <summary>
    /// Service interface for authorization flow.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Creates a Uri with the authorization code.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="redirectUri">The uri responsible for redirecting the user.</param>
        /// <param name="state">The state used to make sure no tempering was made.</param>
        /// <returns>The return uri to the client app as a <see cref="string"/>.</returns>
        Task<string> GenerateAuthorizationCodeRedirectUriAsync(Guid clientId, string redirectUri, string state);
    }
}
