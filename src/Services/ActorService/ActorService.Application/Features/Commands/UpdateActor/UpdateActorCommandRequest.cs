using ActorService.Application.Services.Repositories;
using ActorService.Domain;
using ActorService.Domain.ValueObjects;
using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using MediatR;

namespace ActorService.Application.Features.Commands.UpdateActor;
public sealed class UpdateActorCommandRequest : IRequestCommand {
    public required ActorId Id { get; set; }
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public Byte? Age { get; set; }
    public String? Country { get; set; }
    public String? Biography { get; set; }

    private sealed class Handler : RequestCommandHandler<UpdateActorCommandRequest> {
        private readonly IActorWriteRepository _directorWriteRepository;
        private readonly IActorReadRepository _directorReadRepository;

        public Handler(IActorWriteRepository directorWriteRepository, IActorReadRepository directorReadRepository) {
            _directorWriteRepository = directorWriteRepository;
            _directorReadRepository = directorReadRepository;
        }

        protected override async Task<Unit> HandleCommandAsync(UpdateActorCommandRequest command, CancellationToken cancellationToken) {
            Actor director = await _directorReadRepository.GetByIdAsync(command.Id, cancellationToken)
                ?? throw new Exception("Actor not found");

            director.Update(command.FirstName,
                            command.LastName,
                            command.Age,
                            command.Country,
                            command.Biography);

            await _directorWriteRepository.UpdateAsync(director, cancellationToken);
            await _directorWriteRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}