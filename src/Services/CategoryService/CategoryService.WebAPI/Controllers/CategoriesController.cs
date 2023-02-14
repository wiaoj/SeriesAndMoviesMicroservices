using CategoryService.Application.Features.Categories.Commands.CreateCategory;
using CategoryService.Application.Features.Categories.Commands.DeleteCategory;
using CategoryService.Application.Features.Categories.Queries;
using CategoryService.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase {
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public CategoriesController(ISender sender, IPublisher publisher) {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request) {
        //var x = Category.Create(request.Name, request.Description ?? String.Empty);
        CreateCategoryResponse response = await _sender.Send(new CreateCategoryCommand() {
            Name = request.Name,
            Description = request.Description
        });
        return Ok(response);
    }

    [HttpDelete("[action]/{request.Id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryRequest request) {
        DeleteCategoryResponse response = await _sender.Send(new DeleteCategoryCommand() {
            Id = request.Id,
        });

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllCategoriesRequest request) {
        GetAllCategoriesResponse response = await _sender.Send(new GetAllCategoriesQuery());
        return Ok(response);
    }

    [HttpGet("[action]/{request.Id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdCategoryRequest request) {
        GetByIdCategoryResponse response = await _sender.Send(new GetByIdCategoriesQuery() {
            Id = request.Id
        });
        return Ok(response);
    }
}