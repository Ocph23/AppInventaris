using AppInventaris.Data;
using AppInventaris.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris;

public class LokasiService : ILokasiService
{
    private readonly ApplicationDbContext dbContext;

    public LokasiService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var lokasi = dbContext.Lokasi.FirstOrDefault(item => item.Id == id);
            ArgumentNullException.ThrowIfNull(lokasi, "Data Lokasi Tidak Ditemukan !");
            dbContext.Lokasi.Remove(lokasi);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Lokasi>> Get()
    {
        try
        {
            var datas = dbContext.Lokasi;
            if (datas.Count() <= 0)
                return Enumerable.Empty<Lokasi>();
            return datas.ToList();
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Lokasi> Get(int id)
    {
        try
        {
            var data = await dbContext.Lokasi.AsNoTracking().FirstAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan !");
            return data;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Lokasi> Post(Lokasi model)
    {
        try
        {
            dbContext.Lokasi.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Put(int id, Lokasi model)
    {
        try
        {
            var updated = await dbContext.Lokasi.Where(x=>x.Id==id).ExecuteUpdateAsync(
                (x) =>
                    x.SetProperty(x => x.Name, model.Name)
                        .SetProperty(x => x.Description, model.Description)
            );
            return updated > 0 ? true : false;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
