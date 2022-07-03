using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.TaskDistrubuter.Dal.Entities
{
    public class Assignment : EntityBase
    {
        public string Name { get; set; }

        public int Difficulty { get; set; }

        public int PersonalId { get; set; }
    }
}
