using AppInventaris.Data;
using AppInventaris.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris;


public class PenilaianService : IPenilaianService
{
    private readonly ApplicationDbContext dbContext;

    public PenilaianService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var Penilaian = dbContext.Penilaian.FirstOrDefault(item => item.Id == id);
            ArgumentNullException.ThrowIfNull(Penilaian, "Data Penilaian Tidak Ditemukan !");
            dbContext.Penilaian.Remove(Penilaian);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Penilaian>> Get()
    {
        try
        {
            var datas = dbContext.Penilaian
                .Include(x => x.Pimpinan)
                .Include(x => x.Penilai);
            if (datas.Count() <= 0)
                return Enumerable.Empty<Penilaian>();
            return datas.ToList();
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Penilaian> Get(int id)
    {
        try
        {
            var data = await dbContext.Penilaian
                .Include(x => x.Pimpinan)
                .Include(x => x.Penilai)
                .Include(x => x.Catatan).ThenInclude(x=>x.PemberiCatatan)
                .Include(x => x.DataPenilaian).ThenInclude(x => x.Barang).ThenInclude(x => x.Barang)
                .Include(x => x.DataPenilaian).ThenInclude(x => x.Barang).ThenInclude(x => x.Lokasi)
                .FirstAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan !");
            return data;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Penilaian> Post(Penilaian model)
    {
        try
        {
            dbContext.Penilaian.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Put(int id, Penilaian model)
    {
        try
        {
            var data = dbContext.Penilaian
                .Include(x => x.Penilai)
                .Include(x => x.DataPenilaian)
                .SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data tidak ditemukan !");
            dbContext.Entry(data).CurrentValues.SetValues(model);
            var updated = dbContext.SaveChanges();
            return updated > 0 ? true : false;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Upprove(Penilaian penilaian, CatatanPenilaian catatan)
    {
        try
        {
            var data = dbContext.Penilaian
                .Include(x=>x.Catatan)
                .SingleOrDefault(x => x.Id == penilaian.Id);

            ArgumentNullException.ThrowIfNull(data, "Data tidak ditemukan !");

            data.StatusPenilaian = penilaian.StatusPenilaian;
            if(catatan!=null && !string.IsNullOrEmpty(catatan.Catatan))
            {
                data.Catatan.Add(catatan);
            }
            var updated = dbContext.SaveChanges();
            await Task.Delay(1);
            return updated > 0 ? true : false;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}