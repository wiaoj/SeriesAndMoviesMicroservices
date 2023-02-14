using ActorService.Domain;
using ActorService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActorService.Persistence.EntityConfigurations;
public sealed class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor> {
    public void Configure(EntityTypeBuilder<Actor> builder) {
        builder.ToTable(nameof(Actor));

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ActorId.Create(value));

        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Age);
        builder.Property(x => x.Country);
        builder.Property(x => x.Biography);
    }
}