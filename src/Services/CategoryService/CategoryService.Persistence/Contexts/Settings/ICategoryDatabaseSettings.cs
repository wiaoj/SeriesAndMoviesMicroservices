namespace CategoryService.Persistence.Contexts.Settings;
public interface ICategoryDatabaseSettings {
    public String ConnectionString { get; set; }
    public String DatabaseName { get; set; }
    public String CollectionName { get; set; }
}