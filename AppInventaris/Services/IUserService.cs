namespace AppInventaris.Services;

public interface  IUserService{
    Task Register(RegisterModel model);
    Task Logout();
}