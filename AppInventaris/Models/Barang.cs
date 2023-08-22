namespace AppInventaris.Models;

public class Barang
{

    public int Id { get; set; }
public int KategoriId{get;set;}

    public string Name { get; set; }=string.Empty;
    public string? Description {get;set;}   
    public string? Merek { get; set;}
    public double Berat { get; set;}
    public Dimention Dimensi { get; set;}= new Dimention();
    public Kategori Kategori{get;set;}

}


public class Dimention{
    public Dimention(){}
    
    public Dimention(double panjang,double lebar, double tinggi)
    {
        this.Tinggi = tinggi;
        this.Panjang = panjang;
        this.Lebar = lebar;
        
    }
    public double Panjang {get;set;}
    public double Lebar {get;set;}
    public double Tinggi {get;set;}
}