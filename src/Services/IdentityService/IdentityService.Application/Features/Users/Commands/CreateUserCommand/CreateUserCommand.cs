using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using IdentityService.Application.Repositories;
using IdentityService.Contracts;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;

namespace IdentityService.Application.Features.Users.Commands.CreateUserCommand;
public sealed class CreateUserCommand : IRequestCommand<AuthenticationResponse> {
    public required String FirstName { get; set; }
    public required String LastName { get; set; }
    public required String Email { get; set; }
    public required String Password { get; set; }

    private class CreateUserCommandHandler : RequestCommandHandler<CreateUserCommand, AuthenticationResponse> {
        private readonly IUserWriteRepository _userWriteRepository;

        public CreateUserCommandHandler(IUserWriteRepository userWriteRepository) {
            _userWriteRepository = userWriteRepository;
        }

        protected override async Task<AuthenticationResponse> HandleCommandAsync(CreateUserCommand command, CancellationToken cancellationToken) {

            User user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);

            await _userWriteRepository.AddAsync(user, cancellationToken);
            await _userWriteRepository.SaveChangesAsync(cancellationToken);

            AccessToken token = new() {
                Token = "token",
                Expiration = DateTime.UtcNow.AddMinutes(1)
            };

            return default!;
        }
    }
}