using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Application.CQRS.Queries;
using BuildingBlocks.Core.Exceptions.Types;
using IdentityService.Application.Repositories;
using IdentityService.Application.Services;
using IdentityService.Contracts;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Users;

namespace IdentityService.Application.Features.Authentications.Queries.LoginQuery;
public sealed class LoginQuery : IRequestQuery<LoginQueryResponse> {
    public required String Email { get; set; }
    public required String Password { get; set; }
    public required String IpAddress { get; set; }

    private class LoginQueryHandler : RequestQueryHandler<LoginQuery, LoginQueryResponse> {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IAuthenticationService _authenticationService;

        public LoginQueryHandler(IUserReadRepository userReadRepository,
                                 IAuthenticationService authenticationService) {
            _userReadRepository = userReadRepository;
            _authenticationService = authenticationService;
        }

        protected override async Task<LoginQueryResponse> HandleQueryAsync(LoginQuery query, CancellationToken cancellationToken) {
            User? user = await _userReadRepository.GetUserByEmailAsync(Domain.Users.ValueObjects.Email.Create(query.Email))
                ?? throw new NotFoundException("User not found");

            user.VerifyPassword(query.Password);

            AccessToken token = await _authenticationService.CreateAccessToken(user);

            //RefreshToken refreshToken = await _authenticationService.CreateRefreshToken(user, query.IpAddress, cancellationToken);

            //await _authenticationService.DeleteOldRefreshTokens(user.Id, cancellationToken);

            return new() {
                Token = token,
                RefreshToken = null
            };
        }
    }
}