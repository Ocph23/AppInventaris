using AppInventaris.Data;

namespace AppInventaris.Models
{
    public class Penilaian
    {
        public int Id { get; set; }

        public DateTime Tanggal { get; set; }

        public ApplicationUser? Penilai { get; set; }

        public ApplicationUser? Pimpinan { get; set; }
        public ICollection<PenilaianItem> DataPenilaian { get; set; } = new List<PenilaianItem>();

    }
}
