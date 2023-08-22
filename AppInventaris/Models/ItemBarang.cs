using System.Collections;

namespace AppInventaris.Models;

public class ItemBarang
{
    public int Id { get; set; }
    public  string Kode { get; set; }
    public int BarangId{get;set;}
    public  Barang Barang { get; set; }
    public int LokasiId{get;set;}
    public  Lokasi Lokasi { get; set; }
    public KondisiBarang Kondisi{get;set;}
    public ICollection<Gambar> Galeri {get; set; } = new List<Gambar>();
    public bool AdaGambar=> Galeri.Count > 0;
}
