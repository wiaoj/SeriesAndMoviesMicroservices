using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using DirectorService.Application.Services.Repositories;
using DirectorService.Domain;
using MediatR;

namespace DirectorService.Application.Features.Commands.CreateDirector;
public sealed class CreateDirectorCommandRequest : IRequestCommand {
    public required String FirstName { get; set; }
    public required String LastName { get; set; }
    public required Byte Age { get; set; }
    public required String Country { get; set; }
    public required String Biography { get; set; }

    private sealed class Handler : RequestCommandHandler<CreateDirectorCommandRequest> {
        private readonly IDirectorWriteRepository _directorWriteRepository;

        public Handler(IDirectorWriteRepository directorWriteRepository) {
            _directorWriteRepository = directorWriteRepository;
        }

        protected override async Task<Unit> HandleCommandAsync(CreateDirectorCommandRequest command, CancellationToken cancellationToken) {
            Director director = Director.Create(command.FirstName,
                                                command.LastName,
                                                command.Age,
                                                command.Country,
                                                command.Biography);
            await _directorWriteRepository.AddAsync(director, cancellationToken);
            await _directorWriteRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}