using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.JwtService;

namespace OAuthServer.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class TokenController : Controller
{
    private readonly IJwtService _jwtService;
    
    public TokenController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetToken([FromQuery] TokenRequest request)
    {
        return Ok(
            await _jwtService.GenerateToken
            (
                request.Grant,
                request.RedirectUri,
                request.ClientId,
                request.ClientSecret
            ));
    }
}