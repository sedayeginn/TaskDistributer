using Seda.TaskDistrubuter.Dal.Entities;
using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.TaskDistrubuter.Dal
{
    public class SampleData
    {

        public SampleData()
        {
            
        }


        //public async void CreateTestDataAsync()
        //{
        //    var dbName = "Seda.Distributer.DB";

        //    if (File.Exists(dbName))
        //        File.Delete(dbName);

        //    await using var dbContext = new SqliteDBContext();
        //    await dbContext.Database.EnsureCreatedAsync();
        //    await dbContext.Assignments.AddRangeAsync(new Assignment[] {
        //        new Assignment { Name = "Görev1", Difficulty = 5, PersonalId = 1 },
        //        new Assignment { Name = "Görev2", Difficulty = 3, PersonalId = 2 },
        //        new Assignment { Name = "Görev3", Difficulty = 8, PersonalId = 3 },
        //    });

        //    await dbContext.SaveChangesAsync();

        //    dbContext.Personels?.ToList().ForEach(p =>
        //    {
        //        Console.WriteLine($"{p.Name} rolü {p.Role}");
        //    });

        //    Console.ReadLine();
        //}
    }
}
