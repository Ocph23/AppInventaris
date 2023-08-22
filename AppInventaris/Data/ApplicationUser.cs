using Microsoft.AspNetCore.Identity;

namespace AppInventaris.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            
        }
        public ApplicationUser(string userName) : base(userName)
        {
            Email = "admin@gmail.com"; EmailConfirmed = true;
        }

        public string? Nama { get; set; }
        public string? Jabatan { get; set; }
        public string? Alamat { get; set; }
    }
}
