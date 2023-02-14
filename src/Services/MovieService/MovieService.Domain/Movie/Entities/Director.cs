using BuildingBlocks.Core.Abstractions.Domain.Models;
using MovieService.Domain.Movie.ValueObjects;

namespace MovieService.Domain.Movie.Entities;
public sealed class Director : Entity<DirectorId> {
    public String FirstName { get; private set; }
    public String LastName { get; private set; }
    public DateTime BirthDate { get; private set; }

    private Director(DirectorId id, String firstName, String lastName, DateTime birthDate) : base(id) {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public static Director Create(String firstName, String lastName, DateTime birthDate) {
        return new(DirectorId.CreateUnique, firstName, lastName, birthDate);
    }
}