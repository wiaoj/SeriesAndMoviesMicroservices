using ActorService.Application.Services.Repositories;
using ActorService.Domain;
using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using MediatR;

namespace ActorService.Application.Features.Commands.CreateActor;
public sealed class CreateActorCommandRequest : IRequestCommand {
    public required String FirstName { get; set; }
    public required String LastName { get; set; }
    public required Byte Age { get; set; }
    public required String Country { get; set; }
    public required String Biography { get; set; }

    private sealed class Handler : RequestCommandHandler<CreateActorCommandRequest> {
        private readonly IActorWriteRepository _directorWriteRepository;

        public Handler(IActorWriteRepository directorWriteRepository) {
            _directorWriteRepository = directorWriteRepository;
        }

        protected override async Task<Unit> HandleCommandAsync(CreateActorCommandRequest command, CancellationToken cancellationToken) {
            Actor director = Actor.Create(command.FirstName,
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