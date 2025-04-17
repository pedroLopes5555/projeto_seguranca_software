using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.ClientServices;

namespace OAuthServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : Controller
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientServices)
    {
        _clientService = clientServices;
    }

    [HttpPost]
    public async Task<ActionResult> CreateClient([FromBody] ClientRequest input)
    {
        return Ok(await _clientService.CreateClientAsync(input.Name, input.RedirectUri));
    }
}