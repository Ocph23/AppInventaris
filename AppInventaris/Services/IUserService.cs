using AppInventaris.Models;
using ErrorOr;

namespace AppInventaris.Services;

public interface  IUserService{
    Task<IEnumerable<UserModel>> Get();
    Task<ErrorOr<UserModel>> Register(RegisterUserModel model);
    Task<ErrorOr<bool>> Update(RegisterUserModel model);
    Task Logout();
}