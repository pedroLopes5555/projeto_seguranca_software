using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.Request;
using OAuthServer.Services.UserServices;

namespace OAuthServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userServices)
    {
        _userService = userServices;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] UserRequest input)
    {
        return Ok(await _userService.CreateUserAsync(input.Username, input.Password));
    }
}