using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using IdentityService.Application.Repositories;
using IdentityService.Application.Services;
using IdentityService.Contracts;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;

namespace IdentityService.Application.Features.Authentications.Commands.RegisterCommand;
public sealed class RegisterCommand : IRequestCommand<RegisterCommandResponse> {
    public required String FirstName { get; set; }
    public required String LastName { get; set; }
    public required String Email { get; set; }
    public required String Password { get; set; }
    public required String IpAddress { get; set; }

    private class RegisterCommandHandler : RequestCommandHandler<RegisterCommand, RegisterCommandResponse> {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IAuthenticationService _authenticationService;

        public RegisterCommandHandler(IUserWriteRepository userWriteRepository, IAuthenticationService authenticationService) {
            _userWriteRepository = userWriteRepository;
            _authenticationService = authenticationService;
        }

        protected override async Task<RegisterCommandResponse> HandleCommandAsync(RegisterCommand command, CancellationToken cancellationToken) {

            User user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);

            await _userWriteRepository.AddAsync(user, cancellationToken);


            AccessToken token = await _authenticationService.CreateAccessToken(user);

            //RefreshToken refreshToken = await _authenticationService.CreateRefreshToken(user, command.IpAddress, cancellationToken);
            //refreshToken = null!;

            await _userWriteRepository.SaveChangesAsync(cancellationToken);
            return new() {
                Token = token,
                RefreshToken = null
            };
        }
    }
}