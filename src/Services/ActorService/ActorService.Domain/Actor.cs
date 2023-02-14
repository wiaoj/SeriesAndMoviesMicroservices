using ActorService.Domain.ValueObjects;
using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace ActorService.Domain;
public class Actor : AggregateRoot<ActorId> {
    public String FirstName { get; private set; }
    public String LastName { get; private set; }
    public Byte Age { get; private set; }
    public String Country { get; private set; }
    public String Biography { get; private set; }

    private Actor(ActorId id,
                     String firstName,
                     String lastName,
                     Byte age,
                     String country,
                     String biography) : base(id) {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Country = country;
        Biography = biography;
    }

    public static Actor Create(String firstName, String lastName, Byte age, String country, String biography) {
        return new(ActorId.CreateUnique, firstName, lastName, age, country, biography);
    }

    public Actor Update(String? firstName, String? lastName, Byte? age, String? country, String? biography) {
        return UpdateFirstName(firstName)
                 .UpdateLastName(lastName)
                 .UpdateAge(age)
                 .UpdateCountry(country)
                 .UpdateBiography(biography);
    }

    public Actor UpdateFirstName(String? firstName) {
        FirstName = firstName ?? FirstName;
        return this;
    }

    public Actor UpdateLastName(String? lastName) {
        LastName = lastName ?? LastName;
        return this;
    }

    public Actor UpdateAge(Byte? age) {
        Age = age ?? Age;
        return this;
    }

    public Actor UpdateCountry(String? country) {
        Country = country ?? Country;
        return this;
    }

    public Actor UpdateBiography(String? biography) {
        Biography = biography ?? Biography;
        return this;
    }
}