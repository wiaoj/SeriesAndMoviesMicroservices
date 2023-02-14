using IdentityService.Application.Features.Users.Commands.DeleteUserCommand;
using IdentityService.Application.Features.Users.Queries.GetAllUsersQuery;
using IdentityService.Application.Features.Users.Queries.GetByIdUserQuery;
using IdentityService.Contracts;
using IdentityService.Domain.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase {
    private readonly ISender _sender;

    public UsersController(ISender sender) {
        _sender = sender;
    }

    [Route("[action]/{Id:Guid}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromRoute] DeleteUserRequest request, CancellationToken cancellationToken) {
        await _sender.Send(new DeleteUserCommand() { Id = UserId.Create(request.Id) }, cancellationToken);
        return NoContent();
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken) {
        GetAllUsersResponse response = await _sender.Send(new GetAllUsersQuery(), cancellationToken);
        return Ok(response);
    }

    [Route("[action]/{Id:Guid}")]
    [HttpGet]
    public async Task<IActionResult> GetByUserId([FromRoute] GetByIdUserRequest request, CancellationToken cancellationToken) {
        await _sender.Send(new GetByIdUserQuery() { Id = UserId.Create(request.Id) }, cancellationToken);
        return Ok();
    }
}