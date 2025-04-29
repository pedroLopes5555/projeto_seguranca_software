using OAuthServer.Exeptions;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Services.AuthorizationService;
using OAuthServer.Services.CookieService;

namespace OAuthServer.Services.OAuthService
{
    public class OAuthService : IOAuthService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICookieService _cookieService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OAuthService(IClientRepository clientRepository, ICookieService cookieService, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _cookieService = cookieService;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
            _clientRepository = clientRepository;
        }

        public async Task<String> AuthorizeAsync(
            string responseType,
            Guid clientId,
            string redirectUri
        )
        {
            var client = await _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new NotFoundException("Could not find Client");


            if (_httpContextAccessor.HttpContext == null)
            {
                throw new Exception("HttpContext is null");
            }


            if (!_cookieService.IsUserLoggedIn(_httpContextAccessor.HttpContext))
            {
                var uriBuilder = new UriBuilder(GetBaseUri() + "/api/User/loginpage");
                var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

                query["client_Id"] = clientId.ToString();
                query["redirect_Uri"] = redirectUri;
                query["response_type"] = responseType;

                uriBuilder.Query = query.ToString();
                return uriBuilder.ToString();
            }


            return await _authorizationService.GenerateAuthorizationCodeRedirectUriAsync(clientId, 
                redirectUri,
                Guid.Parse(_cookieService.GetUserIdFromCookie(_httpContextAccessor.HttpContext)) );
        }
        
        
        private string GetBaseUri()
        {
            if(_httpContextAccessor.HttpContext == null)
            {
                throw new Exception("HttpContext is null");
            }
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUri = $"{request.Scheme}://{request.Host}";

            return baseUri;
        }
    }
}