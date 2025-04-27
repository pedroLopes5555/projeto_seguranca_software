using Microsoft.AspNetCore.Mvc;
using OAuthServer.Services.Key;

namespace OAuthServer.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class KeyController : Controller
{
    private readonly IKeyService _keyService;
    public KeyController(IKeyService keyService)
    {
        _keyService = keyService;
    }
    
    [HttpGet]
    public IActionResult GetPubKey()
    {
        return Ok(_keyService.GetPublicKey());
    }
    
}