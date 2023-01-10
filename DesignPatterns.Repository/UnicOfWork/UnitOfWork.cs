using DesignPatterns.EntityFramework.Data;
using DesignPatterns.Repository.Dapper;
using DesignPatterns.Repository.EntityFramework;

namespace DesignPatterns.Repository.UnicOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DesignPatternsClientContext _context;
        private IRepository<Client> _clients;
        private IRepository<Country> _countries;
        private IPetRepository _pets;

        public UnitOfWork(DesignPatternsClientContext context,
                          IPetRepository pets)
        {
            _context = context;
            _pets = pets;
        }
        #region EntityFramework
        public IRepository<Client> Clients
        {
            get
            {
                return _clients == null ?
                    _clients = new Repository<Client>(_context) :
                    _clients;
            }
        }
        public IRepository<Country> Countries
        {
            get
            {
                return _countries == null ?
                    _countries = new Repository<Country>(_context) :
                    _countries;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Dapper


        public IPetRepository Pets
        {
            get
            {
                return _pets;
            }
        }



        #endregion

    }
}
