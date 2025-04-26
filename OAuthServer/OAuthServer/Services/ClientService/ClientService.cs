using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.ModelsDB;
using OAuthServer.Services.Hash;
using OAuthServer.Services.ModelsDTO;
using System.Security.Cryptography;
using OAuthServer.Exeptions;

namespace OAuthServer.Services.ClientService;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IHasher _hasher;
    public ClientService(IClientRepository clientRepository, IHasher hasher)
    {
        _clientRepository = clientRepository;
        _hasher = hasher;
    }

    /// <inheritdoc />
    public async Task<ClientDTO> CreateClientAsync(string name, string redirecturi)
    {
        if (name == "" || redirecturi == "")
            throw new Exception("Invalid fields");

        var secret = GenerateClientSecret();
        var secretHashed = _hasher.GetStringHashed(secret);

        var dbClient = new ClientDB
        {
            Id = Guid.NewGuid(),
            Name = name,
            ClientSecret = secretHashed,
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
