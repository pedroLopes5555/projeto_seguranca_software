using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.UserService;

namespace OAuthServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] UserRequest input)
    {
        return Ok(await _userService.CreateUserAsync(input.Username, input.Password));
    }

    [HttpGet("login")]
    public async Task<ActionResult> Login([FromQuery] LoginRequest info)
    {
        return Redirect(
            await _userService.LoginAsync(
                info.Username, 
                info.Password,
                info.ResponseType,
                info.ClientId,
                info.RedirectUri
            ));
    }
    
    [HttpGet("loginpage")]
    public async Task<ActionResult> LoginPage([FromQuery] OAuthRequest info)
    {
        return View(info);
    }
}