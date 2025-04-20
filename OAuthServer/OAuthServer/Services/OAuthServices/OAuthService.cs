using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.UserRepo;

namespace OAuthServer.Services.OAuthServices
{
    public class OAuthService : IOAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        public OAuthService(IUserRepository userRepository, IClientRepository clientRepository)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
        }

        public async Task<String> AuthorizeAsync(
            string responseType,
            string clientId,
            string redirectUri,
            string scope,
            string state
        )
        {
            //CHECK IF USER IS LOGGED IN
            //IF NOT REDIRECT TO LOGIN AND THEN RETURN HERE

            //CHECK IF CLIENT ID IS VALID, AND IF REDIRECT URI MATCHES

            //GENERATE AUTHORIZATION CODE

            //BUILD THE REDIRECT URL, BEING THE CLIENT REDIRECT URI + CODE + STATE

            //RETURN THE REDIRECT URL BUILT

            return "xxx";
        }
    }
}
