using ActorService.Application.Features.Commands.CreateActor;
using ActorService.Application.Features.Commands.UpdateActor;
using ActorService.Application.Features.Queries.GetAllActorsQuery;
using ActorService.Application.Features.Queries.GetByIdActorQuery;
using ActorService.Contracts;
using ActorService.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ActorService.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ActorController : ControllerBase {
    private readonly ISender _sender;

    public ActorController(ISender sender) {
        _sender = sender;
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> CreateActor([FromBody] CreateActorRequest request, CancellationToken cancellationToken) {
        await _sender.Send(new CreateActorCommandRequest() {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            Country = request.Country,
            Biography = request.Biography,
        }, cancellationToken);
        return Created("", "");
    }

    [Route("[action]/{id.Value}")]
    [HttpPut]
    public async Task<IActionResult> UpdateActor([FromRoute] ActorIdRequest id, [FromBody] UpdateActorRequest request, CancellationToken cancellationToken) {
        await _sender.Send(new UpdateActorCommandRequest() {
            Id = ActorId.Create(id.Value),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            Country = request.Country,
            Biography = request.Biography,
        }, cancellationToken);
        return NoContent();
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAllActors(CancellationToken cancellationToken) {
        GetAllActorsQueryResponse response = await _sender.Send(new GetAllActorsQueryRequest(), cancellationToken);

        return Ok(new GetAllActorsResponse(response.Actors).Actors);
    }

    [Route("[action]/{id.Value}")]
    [HttpGet]
    public async Task<IActionResult> GetById([FromRoute] ActorIdRequest id, CancellationToken cancellationToken) {
        GetByIdActorQueryResponse response = await _sender.Send(new GetByIdActorQueryRequest() { Id = ActorId.Create(id.Value) }, cancellationToken);

        return Ok(new GetByIdActorResponse(response.Actor).Actor);
    }
}