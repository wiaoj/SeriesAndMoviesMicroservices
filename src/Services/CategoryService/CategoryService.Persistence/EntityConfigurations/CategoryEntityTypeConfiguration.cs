using CategoryService.Domain.Category;
using CategoryService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CategoryService.Persistence.EntityConfigurations;
public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category> {
    public void Configure(EntityTypeBuilder<Category> builder) {

        builder.ToTable(CategoryDbContext.TABLE_NAME, CategoryDbContext.DEFAULT_SCHEMA);

        //builder.OwnsOne(x => x.Id, x => {
        //    x.Property(x => x.Value)

        //    .HasColumnName("Id")
        //    .HasDefaultValue(Guid.Parse("11111111-1111-1111-1111-111111111111"));
        //});

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property(x => x.Id)
            //.UseHiLo("category.hilo")
               .IsRequired(true)
            //.HasColumnName("id")
               .HasConversion(categoryId => categoryId.Value, id => id)
               .ValueGeneratedNever();

        //builder.Property(x => x.Id)
        //    .HasConversion(x => x.Value, id => id)s
        //    .ValueGeneratedNever();

        builder.Property(x => x.Name)
            //.HasColumnType("string")
            //.HasConversion(name => name.Value, name => Name.Create(name))
            //.HasColumnName("name")
               .IsRequired(true);

        builder.Property(x => x.Description)
            //.HasColumnName("description")
               .IsRequired(true);

        builder.HasData(new List<Category>() {
            Category.Create("Bilim Kurgu","Bilim kurgu kategorisi"),
            Category.Create("Korku","Korku kategorisi")
        });
    }
}