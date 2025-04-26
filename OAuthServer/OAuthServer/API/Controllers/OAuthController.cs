using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.OAuthService;

namespace OAuthServer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OAuthController : Controller
    {
        private readonly IOAuthService _oAuthService;

        public OAuthController(IOAuthService oAuthService)
        {
            _oAuthService = oAuthService;
        }

        [HttpGet("authorize")]
        public async Task<IActionResult> Authorize([FromQuery] OAuthRequest input)
        {
            return Redirect(
                await _oAuthService.AuthorizeAsync(
                    input.ResponseType,
                    input.ClientId,
                    input.RedirectUri,
                    input.State
                ));
        }
    }
}
