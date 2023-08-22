using AppInventaris.Data;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris.Models;


public class BarangService : IBarangService
{
     private readonly ApplicationDbContext dbContext;

    public BarangService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var Barang = dbContext.Barang.FirstOrDefault(item => item.Id == id);
            ArgumentNullException.ThrowIfNull(Barang, "Data Barang Tidak Ditemukan !");
            dbContext.Barang.Remove(Barang);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Barang>> Get()
    {
        try
        {
            var datas = dbContext.Barang;
            if (datas.Count() <= 0)
                return Enumerable.Empty<Barang>();
            return datas.ToList();
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Barang> Get(int id)
    {
        try
        {
            var data = await dbContext.Barang.AsNoTracking().FirstAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan !");
            return data;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Barang> Post(Barang model)
    {
        try
        {
            dbContext.Barang.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Put(int id, Barang model)
    {
        try
        {
            var updated = await dbContext.Barang.Where(x=>x.Id==model.Id).ExecuteUpdateAsync(
                (x) =>
                    x.SetProperty(x => x.Name, model.Name)
                        .SetProperty(x => x.KategoriId, model.KategoriId)
                        .SetProperty(x => x.Merek, model.Merek)
                        .SetProperty(x => x.Berat, model.Berat)
                        .SetProperty(x => x.Description, model.Description)
                        .SetProperty(x => x.Dimensi, model.Dimensi)
            );
            return updated>0 ?true:false;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}