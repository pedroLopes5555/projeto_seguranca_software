using OAuthServer.Repository.Models;

namespace OAuthServer.Repository.UserRepo;

public interface IUserRepository
{
    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="user">The user entity to create.</param>
    /// <returns>The created user entity.</returns>
    Task<DbUser?> CreateUser(DbUser user);

    /// <summary>
    /// Retrieves a user by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the user.</param>
    /// <returns>The matching user entity, or null if not found.</returns>
    Task<DbUser?> GetUserById(Guid id);

    /// <summary>
    /// Retrieves a user by its username.
    /// </summary>
    /// <param name="username">The username of the client.</param>
    /// <returns>The matching user entity, or null if not found.</returns>
    Task<DbUser?> GetUserByUsername(string username);

    /// <summary>
    /// Updates an existing user in the database.
    /// </summary>
    /// <param name="user">The updated user entity.</param>
    /// <returns>The updated user entity.</returns>
    Task<DbUser?> UpdateUser(DbUser user);

    /// <summary>
    /// Deletes a user by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the user to delete.</param>
    /// <returns>No return.</returns>
    Task DeleteUser(Guid id);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list of all user entities.</returns>
    Task<List<DbUser>> GetAllUsers();
}
