namespace AppInventaris.Models
{
    public class PenilaianItem
    {
        public int Id { get; set; }

        public ItemBarang Barang { get; set; }

        public KondisiBarang StatusPenilaian { get; set; }

        public string? Catatan { get; set; }
    }
}