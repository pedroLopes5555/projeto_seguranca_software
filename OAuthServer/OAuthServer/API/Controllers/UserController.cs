using Microsoft.AspNetCore.Mvc;

namespace OAuthServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: Controller
{

  [HttpGet("test")]
  public IActionResult Test()
  {
    return Ok("hello world");
  }


}