using System.Data.Entity;
using System.Linq;

namespace DataLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private Model1 db;
        private DbSet<TEntity> dbSet;

        public GenericRepository(Model1 db)
        {
            this.db = db;
            dbSet = db.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            TEntity item = FindById(id);
            dbSet.Remove(item);
        }

        public TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public IQueryable<TEntity> Include(params string[] navigationProperty)
        {
            var query = GetAll();
            foreach (var item in navigationProperty)
            {
                query = query.Include(item);
            }
            return query;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(TEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}