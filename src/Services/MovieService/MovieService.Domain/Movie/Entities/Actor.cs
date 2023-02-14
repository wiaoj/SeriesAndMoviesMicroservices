using BuildingBlocks.Core.Abstractions.Domain.Models;
using MovieService.Domain.Movie.ValueObjects;

namespace MovieService.Domain.Movie.Entities;
public sealed class Actor : Entity<ActorId> {
    public String FirstName { get; private set; }
    public String LastName { get; private set; }
    public String Description { get; private set; }
    public DateTime BirthDate { get; private set; }

    private Actor(ActorId id, String firstName, String lastName, String description, DateTime birthDate) : base(id) {
        FirstName = firstName;
        LastName = lastName;
        Description = description;
        BirthDate = birthDate;
    }

    public static Actor Create(String firstName, String lastName, String description, DateTime birthDate) {
        return new(ActorId.CreateUnique, firstName, lastName, description, birthDate);
    }
}