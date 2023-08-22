using AppInventaris.Data;
using AppInventaris.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris;

public class ItemBarangService : IItemBarangService
{
    private readonly ApplicationDbContext dbContext;

    public ItemBarangService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var ItemBarang = dbContext.ItemBarang.FirstOrDefault(item => item.Id == id);
            ArgumentNullException.ThrowIfNull(ItemBarang, "Data ItemBarang Tidak Ditemukan !");
            dbContext.ItemBarang.Remove(ItemBarang);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<ItemBarang>> Get()
    {
        try
        {
            var datas = dbContext.ItemBarang;
            if (datas.Count() <= 0)
                return Enumerable.Empty<ItemBarang>();
            return datas.ToList();
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ItemBarang> Get(int id)
    {
        try
        {
            var data = await dbContext.ItemBarang
                .Include(x => x.Barang)
                .Include(x => x.Lokasi)
                .Include(x => x.Galeri)
                .AsNoTracking()
                .FirstAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan !");
            return data;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ItemBarang> Post(ItemBarang model)
    {
        try
        {
            dbContext.ItemBarang.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Put(int id, ItemBarang model)
    {
        try
        {
            var updated = await dbContext.ItemBarang.ExecuteUpdateAsync(
                (x) =>
                    x.SetProperty(x => x.Kode, model.Kode)
                        .SetProperty(x => x.BarangId, model.BarangId)
                        .SetProperty(x => x.LokasiId, model.LokasiId)
                        .SetProperty(x => x.Kondisi, model.Kondisi)
            );
            return updated > 0 ? true : false;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<bool> AddImages(int iditem, IEnumerable<Gambar> gambars)
    {
        var data = dbContext.ItemBarang
            .Include(x => x.Galeri)
            .SingleOrDefault(x => x.Id == iditem);

        ArgumentNullException.ThrowIfNull(data, "Data Inventaris Tidak Ditemukan !");

        foreach (var item in gambars)
        {
            data.Galeri.Add(item);
        }

        dbContext.SaveChanges();
        return Task.FromResult(true);
    }


    public Task<bool> DeleteImage(int iditem, int gambarId)
    {
        var data = dbContext.ItemBarang
     .Include(x => x.Galeri)
     .SingleOrDefault(x => x.Id == iditem);

        ArgumentNullException.ThrowIfNull(data, "Data Inventaris Tidak Ditemukan !");

        var gambar = data.Galeri.SingleOrDefault(x => x.Id==gambarId);
        ArgumentNullException.ThrowIfNull(gambar, "Data Gambar tidak ditemukan !");
        data.Galeri.Remove(gambar);
        dbContext.SaveChanges();
        return Task.FromResult(true);
    }
}
