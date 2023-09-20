using CustomerDb.Models;

namespace CustomerDb.Repositories
{
    public interface IMasterEntity
    {
        int id { get; set; }
        string name { get; set; }
        int row_status { get; set; }
        DateTime created_at { get; set; }
        string created_by { get; set; }
        DateTime? updated_at { get; set; }
        string? updated_by { get; set; }
    }

    public interface IMasterRepo<T> where T : class, IMasterEntity
    {
        public IEnumerable<T> Get();
        public T? Get(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public void Save();
    }

    public abstract class MasterRepo<TEntity, TContext> where TEntity : class, IMasterEntity where TContext : DataContext
    {
        private readonly TContext _db;

        public MasterRepo(TContext db)
        {
            _db = db;
        }

        public IEnumerable<TEntity> Get() => _db.Set<TEntity>().Where(x => x.row_status == 1).OrderBy(x => x.name);

        public TEntity? Get(int id) => _db.Set<TEntity>().Where(x => x.row_status == 1 && x.id == id).FirstOrDefault();

        public void Create(TEntity entity) => _db.Set<TEntity>().Add(entity);

        public void Update(TEntity entity)
        {
            entity.updated_at = DateTime.Now;
            _db.Set<TEntity>().Update(entity);
        }

        public void Delete(int id)
        {
            TEntity? entity = Get(id);

            if (entity != null)
            {
                entity.row_status = 0;
                Update(entity);
            }
        }

        public void Save() => _db.SaveChanges();
    }
}
