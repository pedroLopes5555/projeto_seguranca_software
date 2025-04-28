using OAuthServer.Exeptions;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.GrantIdRepository;
using OAuthServer.Repository.JWT;
using OAuthServer.Services.CookieService;
using OAuthServer.Services.GrantService;
using OAuthServer.Services.Hash;


namespace OAuthServer.Services.JwtService
{
    public class JwtService : IJwtService
    {
        private readonly IJwtRepository _jwtRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IGrantService _grantService;
        private readonly IHasher _hasher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICookieService _cookieService;
        
        
        private readonly IGrantIdRepository _grantIdRepository;
        
        
        //logger
        private readonly ILogger<JwtService> _logger;

        public JwtService(
            IGrantIdRepository grantIdRepository,
            IJwtRepository jwtRepository, 
            IClientRepository clientRepository, 
            IGrantService grantService, 
            IHasher hasher, 
            IHttpContextAccessor httpContextAccessor,
            ICookieService cookieService,
            ILogger<JwtService> logger
        )
        {
            _grantIdRepository = grantIdRepository;
            _jwtRepository = jwtRepository;
            _clientRepository = clientRepository;
            _grantService = grantService;
            _hasher = hasher;
            _httpContextAccessor = httpContextAccessor;
            _cookieService = cookieService;
            _logger = logger;
        }
        
        public async Task<TokenResponse> GenerateToken(Guid grant, string redirectUri, Guid clientId, string clientSecret)
        {
            // Validate client
            var client = await _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new NotFoundException("Could not find Client");
            _logger.LogInformation("Found client with ID: {ClientId}", clientId);
            
            // if (!_hasher.VerifyText(client.ClientSecret, clientSecret))
            //     throw new UnauthorizedAccessException("Invalid Client Secret");

            if (client.RedirectUri != redirectUri)
                throw new UnauthorizedAccessException("Redirect URI mismatch");
            _logger.LogInformation("Redirect URI matches for client with ID: {ClientId}", clientId);
            
            // Validate grant (authorization code)
            if (!_grantService.CheckGrant(grant))
                throw new NotFoundException("Grant code isn't valid");
            _logger.LogInformation("Grant code is valid for client with ID: {ClientId}", clientId);

            // // Get user info from cookie (for now assuming user is authenticated and their ID is in the cookie)
            // var userId = _cookieService.GetUserIdFromCookie(
            //     _httpContextAccessor.HttpContext ?? throw new Exception("Http Context null")
            // );
            var userId = _grantIdRepository.FindUserIdByGrant(grant);
            if(userId == null) throw new NotFoundException("Could not find user ID");
            
            _logger.LogInformation("User ID: {UserId}", userId);
            
            // Generate token using the JwtRepository
            return _jwtRepository.GenerateToken(userId.ToString(), clientId.ToString());
        }
    }
}
