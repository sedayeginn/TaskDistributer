namespace Seda.TaskDistrubuter.Dal.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        void AddAsync(T entity);

        void DeleteAsync(int id);
    }

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
