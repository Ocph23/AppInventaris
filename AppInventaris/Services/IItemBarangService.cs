using AppInventaris.Models;

namespace AppInventaris;

public interface IItemBarangService{
    Task<IEnumerable<ItemBarang>> Get();
    Task<ItemBarang> Get(int id);

    Task<ItemBarang>Post(ItemBarang model);
    Task<bool>Put(int id, ItemBarang model);
    Task<bool>Delete(int id);

    Task<bool> AddImages(int id, IEnumerable<Gambar> gambars);
    Task<bool> DeleteImage(int iditem, int gambarId);

}
