using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.TaskDistrubuter.Dal.Entities
{
    public class Personal : EntityBase
    {
        public string Name { get; set; }

        public Role Role { get; set; }
    }
}
