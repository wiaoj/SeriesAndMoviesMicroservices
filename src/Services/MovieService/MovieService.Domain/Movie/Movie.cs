using BuildingBlocks.Core.Abstractions.Domain.Models;
using MovieService.Domain.Movie.Entities;
using MovieService.Domain.Movie.ValueObjects;

namespace MovieService.Domain.Movie;
public class Movie : AggregateRoot<MovieId> {
    public String Name { get; private set; }
    public String Description { get; private set; }
    public Rating Rating { get; private set; }

    private readonly List<Director> _directors = new();
    public IReadOnlyCollection<Director> Directors => _directors.AsReadOnly();

    private readonly List<Actor> _actors = new();
    public IReadOnlyCollection<Actor> Actors => _actors.AsReadOnly();

    private Movie(MovieId id, String name, String description) : base(id) {
        Name = name;
        Description = description;
        Rating = Rating.CreateNew(0.0D, 0);
    }

    public static Movie Create(String name, String? description) {
        return new(MovieId.Create(), name, description ?? String.Empty);
    }

    public void AddDirector(Director director) {
        _directors.Add(director);
    }

    public void AddActor(Actor actor) {
        _actors.Add(actor);
    }

    public void createRating(double rating, int count) => Rating.CreateNew(rating, count);
}