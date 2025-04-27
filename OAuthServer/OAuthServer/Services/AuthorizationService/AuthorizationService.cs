using Microsoft.AspNetCore.Authorization;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Services.GrantService;

namespace OAuthServer.Services.AuthorizationService
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IGrantService _grantService;

        public AuthorizationService(IClientRepository clientRepository, IGrantService grantService)
        {
            _clientRepository = clientRepository;
            _grantService = grantService;
        }

        public async Task<string> GenerateAuthorizationCodeRedirectUriAsync(Guid clientId, string redirectUri, string state)
        {
            var client = await _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new Exception("Client not found");

            if (client.RedirectUri != redirectUri)
                throw new Exception("Uri doesnt match");



            var grant = _grantService.CreateGrant();


            var uriBuilder = new UriBuilder(redirectUri);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

            query["code"] = grant.ToString();
            query["state"] = state;

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }
    }
}
