
namespace DesignPatterns.Dapper.Providers
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);


        T GetById(int id);
        IReadOnlyList<T> GetAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}

