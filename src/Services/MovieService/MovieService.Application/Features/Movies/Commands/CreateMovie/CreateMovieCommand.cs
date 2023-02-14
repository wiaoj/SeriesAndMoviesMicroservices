using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using MovieService.Contracts;
using MovieService.Domain.Movie;
using MovieService.Domain.Movie.ValueObjects;
using System.Security.Cryptography;

namespace MovieService.Application.Features.Movies.Commands.CreateMovie;
public sealed class CreateMovieCommand : IRequestCommand<CreateMovieResponse> {
    public required String Name { get; set; }
    public required String? Description { get; set; }

    private class CreateCategoryCommandHandler : RequestCommandHandler<CreateMovieCommand, CreateMovieResponse> {

        public CreateCategoryCommandHandler() { }

        protected override async Task<CreateMovieResponse> HandleCommandAsync(CreateMovieCommand command, CancellationToken cancellationToken) {
            await Task.CompletedTask;
            var createdMovie = Movie.Create(command.Name, command.Description);

            //createdMovie.AddDirector(Domain.Movie.Entities.Director.Create(
            //    "test1", "testsoyad1", new DateTime(1970, 11, 27)
            //    ));
            //createdMovie.AddDirector(Domain.Movie.Entities.Director.Create(
            //    "test2", "testsoyad2", new DateTime(1980, 11, 27)
            //    ));
            //createdMovie.AddDirector(Domain.Movie.Entities.Director.Create(
            //    "test3", "testsoyad3", new DateTime(1957, 11, 27)
            //    ));

            //var x = new Byte[64];
            //using var generator = RandomNumberGenerator.Create();
            //generator.GetBytes(x);
            //createdMovie.AddActor(Domain.Movie.Entities.Actor.Create(
            //    $"{Convert.ToBase64String(x)}", $"{x}", $"{x}", DateTime.UtcNow));


            //Rating rating = Rating.CreateNew(1, 1000);


            return new(
                Id: createdMovie.Id,
                Name: createdMovie.Name,
                Description: createdMovie.Description,
                Rating: createdMovie.Rating,
                Directors: createdMovie.Directors,
                Actors: createdMovie.Actors);
        }
    }
}