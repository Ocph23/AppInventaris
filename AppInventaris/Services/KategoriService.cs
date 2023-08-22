using AppInventaris.Data;
using AppInventaris.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris;


public class KategoriService : IKategoriService
{
      private readonly ApplicationDbContext dbContext;

    public KategoriService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var Kategori = dbContext.Kategori.FirstOrDefault(item => item.Id == id);
            ArgumentNullException.ThrowIfNull(Kategori, "Data Kategori Tidak Ditemukan !");
            dbContext.Kategori.Remove(Kategori);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Kategori>> Get()
    {
        try
        {
            var datas = dbContext.Kategori;
            if (datas.Count() <= 0)
                return Enumerable.Empty<Kategori>();
            return datas.ToList();
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Kategori> Get(int id)
    {
        try
        {
            var data = await dbContext.Kategori.AsNoTracking().FirstAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan !");
            return data;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Kategori> Post(Kategori model)
    {
        try
        {
            dbContext.Kategori.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Put(int id, Kategori model)
    {
        try
        {
            var updated = await dbContext.Kategori.Where(x=>x.Id==id).ExecuteUpdateAsync(
                (x) =>
                    x.SetProperty(x => x.Name, model.Name)
                        .SetProperty(x => x.Description, model.Description)
            );
            return updated>0 ?true:false;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}