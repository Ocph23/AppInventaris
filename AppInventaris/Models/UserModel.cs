namespace AppInventaris.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Jabatan { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string UserType { get; set; }
    }
}
