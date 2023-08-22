using AppInventaris.Models;

namespace AppInventaris;

public interface IKategoriService{
    Task<IEnumerable<Kategori>> Get();
    Task<Kategori> Get(int id);

    Task<Kategori>Post(Kategori model);
    Task<bool>Put(int id, Kategori model);
    Task<bool>Delete(int id);

}
