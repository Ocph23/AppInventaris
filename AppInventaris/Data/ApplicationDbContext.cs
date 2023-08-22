using System.Text.Json;
using AppInventaris.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppInventaris.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Barang> Barang { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Lokasi> Lokasi { get; set; }
        public DbSet<ItemBarang> ItemBarang { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder
            .Entity<Barang>()
            .Property(x => x.Dimensi)
            .HasColumnType("jsonb");
            base.OnModelCreating(builder);
        }
    }
}