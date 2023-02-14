using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieService.Application.Features.Movies.Commands.CreateMovie;
using MovieService.Contracts;

namespace MovieService.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class MoviesController : ControllerBase {
    private readonly ISender _sender;

    public MoviesController(ISender sender) {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieRequest request) {
        CreateMovieResponse response = await _sender.Send(new CreateMovieCommand() {
            Name = request.Name,
            Description = request.Description,
        });

        return Ok(response);
    }
}