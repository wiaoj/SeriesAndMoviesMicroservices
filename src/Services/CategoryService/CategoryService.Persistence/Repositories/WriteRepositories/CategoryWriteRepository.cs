using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using CategoryService.Application.Services.Repositories;
using CategoryService.Domain.Category;
using CategoryService.Domain.Category.ValueObjects;
using CategoryService.Persistence.Contexts;

namespace CategoryService.Persistence.Repositories.WriteRepositories;

public sealed class CategoryWriteRepository : WriteRepository<Category, CategoryId, CategoryDbContext>, ICategoryWriteRepository
{
    public CategoryWriteRepository(CategoryDbContext context) : base(context) { }
}