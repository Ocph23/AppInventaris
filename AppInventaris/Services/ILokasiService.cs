using AppInventaris.Models;

namespace AppInventaris;

public interface ILokasiService{
    Task<IEnumerable<Lokasi>> Get();
    Task<Lokasi> Get(int id);

    Task<Lokasi>Post(Lokasi model);
    Task<bool>Put(int id, Lokasi model);
    Task<bool>Delete(int id);
}
