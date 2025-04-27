using OAuthServer.Services.AuthorizationService;
using OAuthServer.Services.CookieService;

namespace OAuthServer.Services.OAuthService
{
    public class OAuthService : IOAuthService
    {
        private readonly ICookieService _cookieService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OAuthService(ICookieService cookieService, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _cookieService = cookieService;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<String> AuthorizeAsync(
            string responseType,
            Guid clientId,
            string redirectUri,
            string state
        )
        {
            if(!_cookieService.IsUserLoggedIn(_httpContextAccessor.HttpContext))
            {
                var uriBuilder = new UriBuilder("https://localhost:7062/api/User/login");
                var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

                query["clientId"] = clientId.ToString();
                query["redirectUri"] = redirectUri;
                query["state"] = state;

                uriBuilder.Query = query.ToString();
                return uriBuilder.ToString();
            }


            return await _authorizationService.GenerateAuthorizationCodeRedirectUriAsync(clientId, redirectUri, state);
        }
    }
}