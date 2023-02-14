using DirectorService.Application.Features.Commands.CreateDirector;
using DirectorService.Application.Features.Commands.UpdateDirector;
using DirectorService.Application.Features.Queries.GetAllDirectorsQuery;
using DirectorService.Application.Features.Queries.GetByIdDirectorQuery;
using DirectorService.Contracts;
using DirectorService.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class DirectorController : ControllerBase {
    private readonly ISender _sender;

    public DirectorController(ISender sender) {
        _sender = sender;
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorRequest request, CancellationToken cancellationToken) {
        await _sender.Send(new CreateDirectorCommandRequest() {
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
    public async Task<IActionResult> UpdateDirector([FromRoute] DirectorIdRequest id, [FromBody] UpdateDirectorRequest request, CancellationToken cancellationToken) {
        await _sender.Send(new UpdateDirectorCommandRequest() {
            Id = DirectorId.Create(id.Value),
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
    public async Task<IActionResult> GetAllDirectors(CancellationToken cancellationToken) {
        GetAllDirectorsQueryResponse response = await _sender.Send(new GetAllDirectorsQueryRequest(), cancellationToken);

        return Ok(new GetAllDirectorsResponse(response.Directors).Directors);
    }

    [Route("[action]/{id.Value}")]
    [HttpGet]
    public async Task<IActionResult> GetById([FromRoute] DirectorIdRequest id, CancellationToken cancellationToken) {
        GetByIdDirectorQueryResponse response = await _sender.Send(new GetByIdDirectorQueryRequest() { Id = DirectorId.Create(id.Value) }, cancellationToken);

        return Ok(new GetByIdDirectorResponse(response.Director).Director);
    }
}