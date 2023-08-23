using AppInventaris.Models;

namespace AppInventaris;

public interface IPenilaianService{
    Task<IEnumerable<Penilaian>> Get();
    Task<Penilaian> Get(int id);
    Task<Penilaian>Post(Penilaian model);
    Task<bool>Put(int id, Penilaian model);
    Task<bool>Delete(int id);
    Task<bool> Upprove(Penilaian penilaian, CatatanPenilaian catatan);
}
