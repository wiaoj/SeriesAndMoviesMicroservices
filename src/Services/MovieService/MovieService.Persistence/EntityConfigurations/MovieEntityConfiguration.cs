using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Movie;
using MovieService.Domain.Movie.Entities;
using MovieService.Domain.Movie.ValueObjects;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MovieService.Persistence.EntityConfigurations;
public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie> {
    public void Configure(EntityTypeBuilder<Movie> builder) {
        builder.ToTable("Movies");

        builder.HasKey(m => m.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(m => m.Id)
               .IsRequired()
               .ValueGeneratedNever()
               .HasConversion(
                    movieId => movieId.Value,
                    value => MovieId.Create(value));

        builder.OwnsMany(m => m.Directors, director => {
            director.WithOwner().HasForeignKey(nameof(Movie.Id));
            director.ToTable(nameof(Movie.Directors));

            director.HasKey(x => x.Id);
            director.HasIndex(x => x.Id).IsUnique();
            director.Property<DirectorId>(x => x.Id)
                    .IsRequired(true)
                    .ValueGeneratedNever()
                    .HasConversion(
                        directorId => directorId.Value, 
                        value => DirectorId.Create(value));

            director.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            director.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            director.Property(x => x.BirthDate).IsRequired();
        });

        builder.OwnsMany(m => m.Actors, actor => {
            actor.WithOwner().HasForeignKey(nameof(Movie.Id));
            actor.ToTable(nameof(Movie.Actors));

            actor.HasKey(x => x.Id);
            actor.HasIndex(x => x.Id).IsUnique();
            actor.Property<ActorId>(x => x.Id)
                 .IsRequired(true)
                 .ValueGeneratedNever()
                 .HasConversion(
                        directorId => directorId.Value,
                        value => ActorId.Create(value));

            actor.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            actor.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            actor.Property(x => x.Description).HasMaxLength(1000);
            actor.Property(x => x.BirthDate).IsRequired();
        });

        builder.OwnsOne(m => m.Rating, r => {
            r.Property(p => p.Value).HasColumnName("Rating").HasPrecision(3, 2);
            r.Property(p => p.Count).HasColumnName("RatingCount");
        });


    }

    private void ConfigureMoviesTable(EntityTypeBuilder<Movie> builder) {
        builder.ToTable("Movies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MovieId.Create(value));

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);

        builder.OwnsOne(x => x.Rating);
    }

    private void ConfigureDirectorsTable(EntityTypeBuilder<Director> builder) {

    }
}