using AppInventaris.Models;

namespace AppInventaris;

public interface IBarangService{
    Task<IEnumerable<Barang>> Get();
    Task<Barang> Get(int id);
    Task<Barang>Post(Barang model);
    Task<bool>Put(int id, Barang model);
    Task<bool>Delete(int id);
}
