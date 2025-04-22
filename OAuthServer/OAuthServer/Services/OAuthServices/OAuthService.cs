using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.UserRepo;
using OAuthServer.Services.GrantService;

namespace OAuthServer.Services.OAuthServices
{
    public class OAuthService : IOAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IGrantService _grantService;
        public OAuthService(IUserRepository userRepository, IClientRepository clientRepository, IGrantService grantService)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _grantService = grantService;
        }

        public async Task<String> AuthorizeAsync(
            string responseType, // ALWAYS "code"
            Guid clientId,
            string redirectUri,
            string scope, // ALWAYS "sum"
            string state
        )
        {
            //CHECK IF USER IS LOGGED IN
            //IF NOT REDIRECT TO LOGIN AND THEN RETURN HERE

            var client = await _clientRepository.GetClientById(clientId);
            if(client == null)
                throw new Exception("Client not found");

            if (client.RedirectUri != redirectUri)
                throw new Exception("Uri doesnt match");


            var grant = _grantService.CreateGrant();


            var uriBuilder = new UriBuilder(redirectUri);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

            query["code"] = grant.ToString();
            query["state"] = state;

            uriBuilder.Query = query.ToString();
            var finalUri = uriBuilder.ToString();

            return finalUri;
        }
    }
}
