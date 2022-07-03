using Microsoft.EntityFrameworkCore;
using Seda.TaskDistrubuter.Dal.Entities;
using System.Reflection;

namespace Seda.TaskDistrubuter.Dal.Repositories
{
    public class SqliteDBContext : DbContext
    {
        public DbSet<Personal> Personels { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Role> Roles { get; set; }

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
            modelBuilder.Entity<Personal>().ToTable("Personals", "dbo");
            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
