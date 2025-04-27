using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.Jwt;
using OAuthServer.Services.JWT;

namespace OAuthServer.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class TokenController : Controller
{
    private readonly IJwtService _jwtService;
    
    public TokenController(IJwtService jwtService)
    {
        jwtService = jwtService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetToken([FromQuery] TokenRequest request)
    {

        return Ok(await _jwtService.GenerateToken
            (
                request.Grant,
                request.RedirectUri,
                request.ClientId,
                request.ClientSecret
            ));
    }
}