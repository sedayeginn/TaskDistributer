using Seda.TaskDistrubuter.Dal.Entities;
using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.TaskDistrubuter.Dal
{
    public class SampleData
    {
        public async void CreateTestDataAsync()
        {
            var dbName = "Seda.Distributer.DB";

            if (File.Exists(dbName))
                File.Delete(dbName);

            await using var dbContext = new SqliteDBContext();
            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.Personels.AddRangeAsync(new Personel[] {
                new Personel { Name = "Seda", Rol = new Rol { Name = "Developer" }},
                new Personel { Name = "Ayşe", Rol = new Rol { Name = "Analist" }} });

            await dbContext.SaveChangesAsync();

            dbContext.Personels?.ToList().ForEach(p =>
            {
                Console.WriteLine($"{p.Name} rolü {p.Rol}");
            });

            Console.ReadLine();
        }
    }
}
