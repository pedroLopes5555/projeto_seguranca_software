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
            //TODO -> if the client do not exist return a view
            
            
            if(_httpContextAccessor.HttpContext == null)
            {
                throw new Exception("HttpContext is null");
            }
            
            if(!_cookieService.IsUserLoggedIn(_httpContextAccessor.HttpContext))
            {
                var uriBuilder = new UriBuilder(GetBaseUri() + "/api/User/loginpage");
                var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

                query["client_Id"] = clientId.ToString();
                query["redirect_Uri"] = redirectUri;
                query["state"] = state;
                query["response_type"] = responseType;

                uriBuilder.Query = query.ToString();
                return uriBuilder.ToString();
            }


            return await _authorizationService.GenerateAuthorizationCodeRedirectUriAsync(clientId, redirectUri, state);
        }
        
        
        private string GetBaseUri()
        {
            // Retrieve the current request's scheme (http/https), host, and port
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