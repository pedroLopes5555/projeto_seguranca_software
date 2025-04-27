using OAuthServer.Services.ModelsDTO;

namespace OAuthServer.Services.UserService
{
    /// <summary>
    /// Service interface for managing user authentication.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="username">The display username of the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The created user represented as a <see cref="UserDTO"/>.</returns>
        Task<UserDTO> CreateUserAsync(string username, string password);

        /// <summary>
        /// Authenticastes a user.
        /// </summary>
        /// <param name="username">The display username of the user.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="responseType">The Authorization Code Flow, should be "code".</param>
        /// <param name="clientId">The client application's id.</param>
        /// <param name="redirectUri">Where to send the user after approving.</param>
        /// <param name="state">Random value to protect against CSRF</param>
        /// <returns>The URL to the authentication endpoint.</returns>
        Task<string> LoginAsync(string username, string password, string responseType, Guid clientId, string redirectUri, string state);
    }
}
