using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.ModelsDB;
using OAuthServer.Services.ModelsDTO;
using System.Security.Cryptography;
using OAuthServer.Exeptions;

namespace OAuthServer.Services.ClientServices;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    /// <inheritdoc />
    public async Task<ClientDTO> CreateClientAsync(string name, string redirecturi)
    {
        // make verifications and hash secret later

        var secret = GenerateClientSecret();

        var dbClient = new ClientDB
        {
            Id = Guid.NewGuid(),
            Name = name,
            ClientSecret = secret,
            RedirectUri = redirecturi,
        };

        var createdClient = await _clientRepository.CreateClient(dbClient);

        if (createdClient == null)
            throw new NotFoundException("Could not Create Client");
        return new ClientDTO
        {
            Id = createdClient.Id.ToString(),
            Name = createdClient.Name,
            RedirectUri = createdClient.RedirectUri,
            ClientSecret = secret,
        };
    }


    // THIS IS A UTILS METHOD CHANGE PLACEMENT AFTER, MIGHT EVEN CHANGE THE WHOLE METHOD
    private string GenerateClientSecret(int length = 64)
    {
        var bytes = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}
