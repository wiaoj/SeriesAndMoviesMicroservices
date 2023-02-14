namespace CategoryService.Domain.Entities.Base;
public abstract class IBaseEntity {
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public IBaseEntity() {
        CreatedDate = new DateTime();
    }

    public IBaseEntity(Guid id) : this() {
        Id = id;
    }
}