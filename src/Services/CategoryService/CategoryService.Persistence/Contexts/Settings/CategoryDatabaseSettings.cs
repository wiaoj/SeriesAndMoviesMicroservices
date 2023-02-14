namespace CategoryService.Persistence.Contexts.Settings;

public class CategoryDatabaseSettings : ICategoryDatabaseSettings {
    public const String SECTION_NAME = "CategoryDatabaseSettings";
    public String DatabaseName { get; set; } = "CategoryMongoDb";
    public String CollectionName { get; set; } = "Categories";
    public String ConnectionString { get; set; } = "mongodb://localhost:27017";
}