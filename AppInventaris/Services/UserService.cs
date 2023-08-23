
using AppInventaris.Data;
using AppInventaris.Models;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _dbContext;
    public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public Task<IEnumerable<UserModel>> Get()
    {
        var result = from u in _dbContext.Users
                     join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                     join r in _dbContext.Roles on ur.RoleId equals r.Id
                     select new UserModel
                     {
                         Active = u.EmailConfirmed,
                         Address = u.Alamat,
                         Email = u.Email,
                         Jabatan = u.Jabatan,
                         Name = u.Nama,
                         Id = u.Id,
                         UserType = r.Name
                     };

        
        return Task.FromResult(result.Where(x=>x.UserType.ToLower()!="admin").AsEnumerable());
    }

  
    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<UserModel>> Register(RegisterUserModel model)
    {
        try
        {
            var user = new ApplicationUser(model.Email)
            {
                Alamat = model.Alamat,
                Jabatan = model.Jabatan,
                Nama = model.Nama,
                EmailConfirmed = true
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRoleAsync(user, model.UserType);
                if (identityResult.Succeeded)
                {
                    return new UserModel { Active = user.EmailConfirmed, Email = user.Email, Jabatan = user.Jabatan, Name = user.Nama, UserType = model.UserType.ToString() };
                }
                else
                {
                    await _userManager.DeleteAsync(user);
                }
            }
            return new List<Error>(identityResult.Errors.Select(x => Error.Failure(x.Code, x.Description)));
        }
        catch (Exception ex)
        {
            return Error.Unexpected(description: ex.Message);
        }
    }

    public async Task<ErrorOr<bool>> Update(RegisterUserModel model)
    {
        try
        {
           var resut = await _dbContext.Users.Where(x=>x.Id==model.Id).ExecuteUpdateAsync(x => x
            .SetProperty(z=>z.Alamat, model.Alamat)
            .SetProperty(z=>z.Jabatan, model.Jabatan)
            .SetProperty(z=>z.EmailConfirmed, model.Active)
            .SetProperty(z => z.Nama, model.Nama));
            
            return resut==1? true: false;
        }
        catch (Exception ex)
        {
            return Error.Unexpected(description: ex.Message);
        }
    }
}