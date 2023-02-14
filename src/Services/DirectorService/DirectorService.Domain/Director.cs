using BuildingBlocks.Core.Abstractions.Domain.Models;
using DirectorService.Domain.ValueObjects;

namespace DirectorService.Domain;
public class Director : AggregateRoot<DirectorId> {
    public String FirstName { get; private set; }
    public String LastName { get; private set; }
    public Byte Age { get; private set; }
    public String Country { get; private set; }
    public String Biography { get; private set; }

    private Director(DirectorId id,
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

    public static Director Create(String firstName, String lastName, Byte age, String country, String biography) {
        return new(DirectorId.CreateUnique, firstName, lastName, age, country, biography);
    }

    public Director Update(String? firstName, String? lastName, Byte? age, String? country, String? biography) {
       return UpdateFirstName(firstName)
                .UpdateLastName(lastName)
                .UpdateAge(age)
                .UpdateCountry(country)
                .UpdateBiography(biography);
    }

    public Director UpdateFirstName(String? firstName) {
        FirstName = firstName ?? FirstName;
        return this;
    }

    public Director UpdateLastName(String? lastName) {
        LastName = lastName ?? LastName;
        return this;
    }

    public Director UpdateAge(Byte? age) {
        Age = age ?? Age;
        return this;
    }

    public Director UpdateCountry(String? country) {
        Country = country ?? Country;
        return this;
    }

    public Director UpdateBiography(String? biography) {
        Biography = biography ?? Biography;
        return this;
    }
}