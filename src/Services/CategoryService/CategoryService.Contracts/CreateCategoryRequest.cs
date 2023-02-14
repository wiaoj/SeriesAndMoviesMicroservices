using CategoryService.Domain.Category;
using CategoryService.Domain.Category.ValueObjects;

namespace CategoryService.Contracts;
public sealed record CreateCategoryRequest(
    String Name,
    String? Description);

public sealed record CreateCategoryResponse(CategoryId Id, String Name, String? Description);

public sealed record UpdateCategoryRequest(CategoryId Id, String Name, String? Description);
public sealed record UpdateCategoryResponse(CategoryId Id, String Name, String Description);

public sealed record DeleteCategoryRequest(Guid Id);
public sealed record DeleteCategoryResponse(Guid Id);

public sealed record GetAllCategoriesRequest();
public sealed record GetAllCategoriesResponse(IEnumerable<Category> Categories);

public sealed record GetByIdCategoryRequest(Guid Id);
public sealed record GetByIdCategoryResponse(CategoryId Id, String Name, String Description);