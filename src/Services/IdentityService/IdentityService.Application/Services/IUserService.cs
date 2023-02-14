namespace IdentityService.Application.Services;
public interface IUserService {
    public Task ChangePassword(String password, CancellationToken cancellationToken);
}