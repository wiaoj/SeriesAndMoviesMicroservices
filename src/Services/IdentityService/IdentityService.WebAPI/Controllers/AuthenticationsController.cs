using IdentityService.Application.Features.Authentications.Commands.RegisterCommand;
using IdentityService.Application.Features.Authentications.Queries.LoginQuery;
using IdentityService.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class AuthenticationsController : ControllerBase {
    private readonly ISender _sender;

    public AuthenticationsController(ISender sender) {
        _sender = sender;
    }

    protected String? IpAddress =>
        Request.Headers.ContainsKey("X-Forwarded-For")
        ? Request.Headers["X-Forwarded-For"]
        : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();


    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken) {
        RegisterCommandResponse response = await _sender.Send(new RegisterCommand() {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            IpAddress = IpAddress ?? String.Empty
        }, cancellationToken);
        return Created("", new AuthenticationResponse(response.Token, response.RefreshToken));
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken) {
        LoginQueryResponse response = await _sender.Send(new LoginQuery() {
            Email = request.Email,
            Password = request.Password,
            IpAddress = IpAddress ?? String.Empty
        }, cancellationToken);
        return Ok(new AuthenticationResponse(response.Token, response.RefreshToken));
    }
}
