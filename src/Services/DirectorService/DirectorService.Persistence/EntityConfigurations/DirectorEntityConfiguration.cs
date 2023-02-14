using DirectorService.Domain;
using DirectorService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectorService.Persistence.EntityConfigurations;
public sealed class DirectorEntityTypeConfiguration : IEntityTypeConfiguration<Director> {
    public void Configure(EntityTypeBuilder<Director> builder) {
        builder.ToTable(nameof(Director));

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DirectorId.Create(value));

        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Age);
        builder.Property(x => x.Country);
        builder.Property(x => x.Biography);
    }
}