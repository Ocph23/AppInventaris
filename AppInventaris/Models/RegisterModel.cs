namespace AppInventaris.Models;

public class RegisterModel{
    public string Nama{get;set;}

    public string Email{get;set;}

    public string Alamat{get;set;}

    public string Jabatan{get;set;}

    public string Password{get;set;}

    public string ConfirmPassword{get;set;}

    public UserType UserType{get;set;}
}


public enum UserType
{
    Pimpinan,
    Penilai,
    Admin
}