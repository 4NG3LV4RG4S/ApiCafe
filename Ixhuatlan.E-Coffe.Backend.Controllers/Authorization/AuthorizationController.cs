using Ixhuatlan.E_Coffe.Backend.Entities.DTOs.Authorization;
using Ixhuatlan.E_Coffe.Backend.Ports.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ixhuatlan.E_Coffe.Backend.Controllers.Authorization;

[ApiController]
[Route("api/Token/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly ITokenInputPort InputPort;

    public AuthorizationController(ITokenInputPort inputPort)
    {
        InputPort = inputPort;
    }

    [HttpPost("GetTokenAuth")]
    public IActionResult GetToken([FromBody] UserDto data)
    {
        if (InputPort.ValidateCredentials(data.UserName, data.Password))
        {
            TokenRequestDto token = InputPort.GenerateToken(data.UserName);
            return Ok(token);
        }
        return Unauthorized();
    }
}