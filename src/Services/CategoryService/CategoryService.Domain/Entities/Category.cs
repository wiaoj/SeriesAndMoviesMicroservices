using CategoryService.Domain.Entities.Base;

namespace CategoryService.Domain.Entities;
public class Category : IBaseEntity {
    public String Name { get; set; }
    public String Description { get; set; }
    //public DateTime Year { get; set; }
    //public String Language { get; set; }

    public Category() { }

    public Category(Guid id, String name, String description/*, DateTime year, String language*/) : this() {
        Id = id;
        Name = name;
        Description = description;
        //Year = year;
        //Language = language;
    }
}