using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using IdentityService.Application.Repositories;
using IdentityService.Domain.Users.ValueObjects;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.DeleteUserCommand;
public sealed class DeleteUserCommand : IRequestCommand {
    public required UserId Id { get; set; }

    private class DeleteUserCommandHandler : RequestCommandHandler<DeleteUserCommand> {
        private readonly IUserWriteRepository _userWriteRepository;

        public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository) {
            _userWriteRepository = userWriteRepository;
        }

        protected override async Task<Unit> HandleCommandAsync(DeleteUserCommand command, CancellationToken cancellationToken) {
            await _userWriteRepository.DeleteAsync(command.Id, cancellationToken);
            await _userWriteRepository.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}