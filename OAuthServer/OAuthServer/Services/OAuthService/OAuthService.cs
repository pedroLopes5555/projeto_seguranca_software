using OAuthServer.Repository.UserRepo;
using OAuthServer.Services.AuthorizationService;

namespace OAuthServer.Services.OAuthService
{
    public class OAuthService : IOAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizationService _authorizationService;

        public OAuthService(IUserRepository userRepository, IAuthorizationService authorizationService)
        {
            _userRepository = userRepository;
            _authorizationService = authorizationService;
        }

        public async Task<String> AuthorizeAsync(
            string responseType,
            Guid clientId,
            string redirectUri,
            string state
        )
        {
            //CHECK IF USER IS LOGGED IN
            //IF NOT REDIRECT TO LOGIN AND THEN RETURN HERE
            //redirecionar para a pagina com os dados de autorização (clientid, redirecturi, state)

            return await _authorizationService.GenerateAuthorizationCodeRedirectUriAsync(clientId, redirectUri, state);
        }
    }
}