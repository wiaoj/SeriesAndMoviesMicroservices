using MovieService.Domain.Movie;
using MovieService.Domain.Movie.Entities;
using MovieService.Domain.Movie.ValueObjects;

namespace MovieService.Contracts;
public sealed record class CreateMovieRequest(String Name, String? Description);
public sealed record class CreateMovieResponse(MovieId Id, String Name, String Description, Rating Rating, IReadOnlyCollection<Director> Directors, IReadOnlyCollection<Actor> Actors);
