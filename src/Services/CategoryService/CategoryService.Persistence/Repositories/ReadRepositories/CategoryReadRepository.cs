using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using CategoryService.Application.Services.Repositories;
using CategoryService.Domain.Category;
using CategoryService.Domain.Category.ValueObjects;
using CategoryService.Persistence.Contexts;

namespace CategoryService.Persistence.Repositories.ReadRepositories;
public sealed class CategoryReadRepository : ReadRepository<Category, CategoryId, CategoryDbContext>, ICategoryReadRepository {
    public CategoryReadRepository(CategoryDbContext context) : base(context) { }
}