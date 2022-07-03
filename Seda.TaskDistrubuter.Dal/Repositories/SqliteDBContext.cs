using Microsoft.EntityFrameworkCore;
using Seda.TaskDistrubuter.Dal.Entities;
using System.Reflection;

namespace Seda.TaskDistrubuter.Dal.Repositories
{
    public class SqliteDBContext : DbContext
    {
        public DbSet<Personel> Personels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=Seda.Distributer.DB", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("Personels", "dbo");
            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasKey(k => k.PersonelId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
