using Microsoft.AspNetCore.Authorization;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.GrantIdRepository;
using OAuthServer.Services.GrantService;

namespace OAuthServer.Services.AuthorizationService
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IGrantService _grantService;
        private readonly IGrantIdRepository _grantIdRepository;
        public AuthorizationService(IClientRepository clientRepository, IGrantService grantService, IGrantIdRepository grantIdRepository)
        {
            _grantIdRepository = grantIdRepository;
            _clientRepository = clientRepository;
            _grantService = grantService;
        }

        public async Task<string> GenerateAuthorizationCodeRedirectUriAsync(Guid clientId, string redirectUri, Guid userId)
        {
            var client = await _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new Exception("Client not found");

            if (client.RedirectUri != redirectUri)
                throw new Exception("Uri doesnt match");

            var grant = Guid.NewGuid();
            _grantIdRepository.AddGrantUserId(grant, userId);

            var uriBuilder = new UriBuilder(redirectUri);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

            query["code"] = grant.ToString();
            
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }
    }
}
