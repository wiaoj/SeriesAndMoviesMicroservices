using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using DirectorService.Application.Services.Repositories;
using DirectorService.Domain;
using DirectorService.Domain.ValueObjects;
using MediatR;

namespace DirectorService.Application.Features.Commands.UpdateDirector;
public sealed class UpdateDirectorCommandRequest : IRequestCommand {
    public required DirectorId Id { get; set; }
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public Byte? Age { get; set; }
    public String? Country { get; set; }
    public String? Biography { get; set; }

    private sealed class Handler : RequestCommandHandler<UpdateDirectorCommandRequest> {
        private readonly IDirectorWriteRepository _directorWriteRepository;
        private readonly IDirectorReadRepository _directorReadRepository;

        public Handler(IDirectorWriteRepository directorWriteRepository, IDirectorReadRepository directorReadRepository) {
            _directorWriteRepository = directorWriteRepository;
            _directorReadRepository = directorReadRepository;
        }

        protected override async Task<Unit> HandleCommandAsync(UpdateDirectorCommandRequest command, CancellationToken cancellationToken) {
            Director director = await _directorReadRepository.GetByIdAsync(command.Id, cancellationToken) 
                ?? throw new Exception("Director not found");

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