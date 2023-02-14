using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using IdentityService.Application.Services;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.ChangePasswordCommand;
public sealed class ChangeUserPasswordCommandRequest : IRequestCommand {
    public required String Password { get; set; }

    private class ChangeUserPasswordCommandHandler : RequestCommandHandler<ChangeUserPasswordCommandRequest> {
        private readonly IUserService _userService;

        public ChangeUserPasswordCommandHandler(IUserService userService) {
            _userService = userService;
        }

        protected override async Task<Unit> HandleCommandAsync(ChangeUserPasswordCommandRequest command, CancellationToken cancellationToken) {
            await _userService.ChangePassword(command.Password, cancellationToken);
            return Unit.Value;
        }
    }
}