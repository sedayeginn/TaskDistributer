using Seda.TaskDistrubuter.Dal.Entities;
using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.TaskDistrubuter.Dal
{
    public class SampleData
    {

        public SampleData()
        {
            
        }


        public async void CreateTestDataAsync()
        {
            var dbName = "Seda.Distributer.DB";

            if (File.Exists(dbName))
                File.Delete(dbName);

            await using var dbContext = new SqliteDBContext();
            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.Personels.AddRangeAsync(new Personal[] {
                new Personal { Name = "Dev1", Role = new Role { Name = "Developer" }},
                new Personal { Name = "Dev2", Role = new Role { Name = "Developer" }},
                new Personal { Name = "Ayşe", Role = new Role { Name = "Analist" }} });

            await dbContext.SaveChangesAsync();

            dbContext.Personels?.ToList().ForEach(p =>
            {
                Console.WriteLine($"{p.Name} rolü {p.Role}");
            });

            Console.ReadLine();
        }
    }
}
