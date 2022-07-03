namespace Seda.TaskDistrubuter.Dal.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly SqliteDBContext _dbContext;

        public Repository(SqliteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async void DeleteAsync(int id)
        {
            var entity = _dbContext.Set<T>().Single(x => x.Id == id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public T GetByIdAsync(int id)
        {
            return _dbContext.Set<T>().Single(x => x.Id == id);
        }
    }
}
