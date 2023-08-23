namespace AppInventaris.Models;

public class RegisterUserModel{

    public string Id { get; set; }
    public string Nama{get;set;}

    public string Email{get;set;}

    public string Alamat{get;set;}

    public string Jabatan{get;set;}

    public string Password{get;set;}

    public string ConfirmPassword{get;set;}

    public string UserType{get;set;}

    public bool Active { get; set;}
}


//public enum UserType
//{
//    None,
//    Pimpinan,
//    Penilai,
//    Admin
//}