using CategoryService.Domain.Entities;
using MongoDB.Driver;

namespace CategoryService.Persistence.Contexts.Seeds;
public class CategoryContextSeed {
    public static void SeedData(IMongoCollection<Category> categoryCollection) {
        Boolean existCategory = categoryCollection.Find(p => true).Any();
        if(existCategory is false)
            categoryCollection.InsertManyAsync(GetConfigureCategory());
    }

    private static IEnumerable<Category> GetConfigureCategory() {
        return new List<Category>() {
            new Category {
                Name = "Korku",
                Description = "Korku Kategorisi",
            },
            new Category {
                Name = "Dram",
                Description = "Dram Kategorisi",
            },
        };
    }
}