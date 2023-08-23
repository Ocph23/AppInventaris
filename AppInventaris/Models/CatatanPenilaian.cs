using AppInventaris.Data;

namespace AppInventaris.Models
{
    public class CatatanPenilaian
    {
        public int Id { get; set; }

        public DateTime Tanggal { get; set; }
        public string Catatan { get; set; }
        public ApplicationUser PemberiCatatan { get; set; }
    }
}