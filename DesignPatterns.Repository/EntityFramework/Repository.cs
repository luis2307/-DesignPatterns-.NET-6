using DesignPatterns.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /*
          This is where we communicate with database,
          and it stands for all the classes.              
       */

        private DesignPatternsClientContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DesignPatternsClientContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity data) => _dbSet.Add(data);

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            if (dataToDelete != null) _dbSet.Remove(dataToDelete);
        }
        public void DeleteByGuid(Guid id)
        {
            var dataToDelete = _dbSet.Find(id);
            if (dataToDelete != null) _dbSet.Remove(dataToDelete);
        }

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity Get(int id) => _dbSet.Find(id);
        public TEntity FindOneByGuid(Guid id) => _dbSet.Find(id);

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
        public void Save() => _context.SaveChanges();


    }
}
