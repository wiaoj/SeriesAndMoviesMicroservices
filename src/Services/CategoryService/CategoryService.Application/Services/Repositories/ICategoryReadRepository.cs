using BuildingBlocks.Core.Abstractions.Repositories;
using CategoryService.Domain.Category;
using CategoryService.Domain.Category.ValueObjects;

namespace CategoryService.Application.Services.Repositories;
public interface ICategoryReadRepository : IAsyncReadRepository<Category, CategoryId> { }