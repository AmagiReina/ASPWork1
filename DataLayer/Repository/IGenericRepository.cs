using System.Linq;

namespace DataLayer.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /**
         * SELECT * FROM table;
         * */
        IQueryable<TEntity> GetAll();

        /**
         * SELECT * FROM table WHERE id = :id;
         * */
        TEntity FindById(int id);

        /**
         *  INSERT
         * */
        void Create(TEntity item);

        /**
         *  UPDATE
         * */
        void Update(TEntity item);

        /**
         *  DELETE
         * */
        void Delete(int id);

        /**
         *  COMMIT or SaveChanges
         * */
        void Save();

        /**
         *  JOIN
         * */
        IQueryable<TEntity> Include(params string[] navigationProperty);
    }
}
