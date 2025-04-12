using OAuthServer.Repository.Models;

namespace OAuthServer.Repository.ClientRepo;

public interface IClientRepository
{
    /// <summary>
    /// Creates a new client in the database.
    /// </summary>
    /// <param name="client">The client entity to create.</param>
    /// <returns>The created client entity.</returns>
    Task<DbClient?> CreateClient(DbClient client);

    /// <summary>
    /// Retrieves a client by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the client.</param>
    /// <returns>The matching client entity, or null if not found.</returns>
    Task<DbClient?> GetClientById(Guid id);

    /// <summary>
    /// Retrieves a client by its name.
    /// </summary>
    /// <param name="name">The name of the client.</param>
    /// <returns>The matching client entity, or null if not found.</returns>
    Task<DbClient?> GetClientByName(string name);

    /// <summary>
    /// Retrieves a client by its secret.
    /// </summary>
    /// <param name="secret">The secret of the client.</param>
    /// <returns>The matching client entity, or null if not found.</returns>
    Task<DbClient?> GetClientBySecret(string secret);

    /// <summary>
    /// Updates an existing client in the database.
    /// </summary>
    /// <param name="client">The updated client entity.</param>
    /// <returns>The updated client entity.</returns>
    Task<DbClient?> UpdateClient(DbClient client);

    /// <summary>
    /// Deletes a client by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the client to delete.</param>
    /// <returns>The deleted client entity.</returns>
    Task DeleteClient(Guid id);

    /// <summary>
    /// Retrieves all clients from the database.
    /// </summary>
    /// <returns>A list of all client entities.</returns>
    Task<List<DbClient>> GetAllClients();

    
    
}