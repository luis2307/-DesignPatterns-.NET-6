using DesignPatterns.EntityFramework.Data;
using DesignPatterns.Repository.Dapper;
using DesignPatterns.Repository.EntityFramework;

namespace DesignPatterns.Repository.UnicOfWork
{
    public interface IUnitOfWork
    {
        #region EntityFramework
        public IRepository<Client> Clients { get; }
        public IRepository<Country> Countries { get; }
        public void Save();
        #endregion

        #region Dapper 
        IPetRepository Pets { get; }
        #endregion

    }
}
