using Microsoft.AspNetCore.Identity;

namespace AppInventaris.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string userName) : base(userName)
        {
            Email = userName; EmailConfirmed = true;
        }
        public string? Nama { get; set; }
        public string? Jabatan { get; set; }
        public string? Alamat { get; set; }
    }
}
