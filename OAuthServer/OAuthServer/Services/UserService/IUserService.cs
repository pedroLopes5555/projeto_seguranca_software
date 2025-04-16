using OAuthServer.Services.Response;

namespace OAuthServer.Services.UserServices
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
    }
}
