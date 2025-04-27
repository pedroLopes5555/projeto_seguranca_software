using Microsoft.EntityFrameworkCore;
using OAuthServer.Exeptions;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Services.CookieService;
using OAuthServer.Services.GrantService;
using OAuthServer.Services.Hash;
using OAuthServer.Services.JWT;

namespace OAuthServer.Services.JwtService;

public class JwtService : IJwtService
{
    private readonly IJwtRepository _jwtRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IGrantService _grantService;
    private readonly IHasher _hasher;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICookieService _cookieService;

    public JwtService(
        IJwtRepository jwtRepository, 
        IClientRepository clientRepository, 
        IGrantService grantService, 
        IHasher hasher, 
        IHttpContextAccessor httpContextAccessor,
        ICookieService cookieService
    )
    {
        _jwtRepository = jwtRepository;
        _clientRepository = clientRepository;
        _grantService = grantService;
        _hasher = hasher;
        _httpContextAccessor = httpContextAccessor;
        _cookieService = cookieService;
    }
    
    public async Task<string> GenerateToken(Guid grant, string redirectUri, Guid clientId, string clientSecret)
    {
        var client = await _clientRepository.GetClientById(clientId);
        if (client == null)
            throw new NotFoundException("Could not find Client");

        if (!_hasher.VerifyText(client.ClientSecret, clientSecret))
            throw new Exception("Invalid Client Secret");

        if (client.RedirectUri != redirectUri)
            throw new NotFoundException("Uri wasnt found");

        if (!_grantService.CheckGrant(grant))
            throw new NotFoundException("Grant code isnt valid");


        var userId = _cookieService.GetUserIdFromCookie(_httpContextAccessor.HttpContext);
        var clientIdString = clientId.ToString();

        return _jwtRepository.GenerateToken(userId, clientIdString);
    }
    
    
}