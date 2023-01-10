namespace DesignPatterns.Repository.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class
    {

        /*
            This is where we put all the methods
            that are common for all entities.
         */

        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        TEntity FindOneByGuid(Guid id);
        void Add(TEntity data);
        void Delete(int id);
        void DeleteByGuid(Guid id);
        void Update(TEntity data);
        void Save();

    }
}
