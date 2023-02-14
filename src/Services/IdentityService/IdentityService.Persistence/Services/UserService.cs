using IdentityService.Application.Repositories;
using IdentityService.Application.Services;

namespace IdentityService.Persistence.Services;
public class UserService : IUserService {
    private readonly IUserWriteRepository _userWriteRepository;

    public UserService(IUserWriteRepository userWriteRepository) {
        _userWriteRepository = userWriteRepository;
    }

    public Task ChangePassword(String password, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}