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
        private static bool _created = false;

        public SqliteDBContext(DbContextOptions<SqliteDBContext> options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }

        }

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
            modelBuilder.Entity<Assignment>().ToTable("Assignments", "dbo");
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
