using Microsoft.AspNetCore.Mvc;
using OAuthServer.API.ModelsRequest;
using OAuthServer.Services.ClientService;

namespace OAuthServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : Controller
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateClient([FromBody] ClientRequest input)
    {
        return Ok(await _clientService.CreateClientAsync(input.Name, input.RedirectUri));
    }
}