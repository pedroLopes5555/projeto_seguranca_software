using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.JwtService;

namespace OAuthServer.API.Controllers;


[ApiController]
[Route("api/oauth/[controller]")]

public class TokenController : Controller
{
    private readonly IJwtService _jwtService;
    //logger
    private readonly ILogger<TokenController> _logger;
    public TokenController(IJwtService jwtService, ILogger<TokenController> logger)
    {
        _logger = logger;
        _jwtService = jwtService;
    }

    /*
     * 🛠 Your OAuth server must accept a POST /token with this body:
       
       POST /api/oauth/token
       Content-Type: application/x-www-form-urlencoded
       
       grant_type=authorization_code
       code=your-code-here
       redirect_uri=http://localhost:3000/callback
       client_id=your-client-id
       client_secret=your-client-secret
       
       and respond like:
       
       {
         "access_token": "the-jwt-or-token",
         "token_type": "Bearer",
         "expires_in": 3600,
         "refresh_token": "optional"
       }
     */
    [HttpPost]
    public async Task<IActionResult> GetToken([FromForm] TokenRequest request)
    {
        // log that we are in this method
        _logger.LogInformation("GetToken called with request: {request}", request);
    
        var result = await _jwtService.GenerateToken(
            request.code,
            request.redirect_uri,
            request.client_id,
            request.client_secret
        );
    
        _logger.LogInformation("GetToken result: {result}", result);
        return Ok(result);
    }

}