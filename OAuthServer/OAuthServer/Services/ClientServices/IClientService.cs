using OAuthServer.Services.ModelsDTO;

namespace OAuthServer.Services.ClientServices;

/// <summary>
/// Service interface for managing client creation.
/// </summary>
public interface IClientService
{
    /// <summary>
    /// Creates a client user in the database.
    /// </summary>
    /// <param name="name">The display name of the client.</param>
    /// <param name="redirecturi">The uri responsible for redirecting the user.</param>
    /// <returns>The created client represented as a <see cref="ClientDTO"/>.</returns>
    Task<ClientDTO> CreateClientAsync(string name, string redirecturi);
}
