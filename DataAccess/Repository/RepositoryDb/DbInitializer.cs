using System;
using System.Data.Entity;

namespace DataAccess.Repository.RepositoryDb
{
    public class DbInitializer : IDatabaseInitializer<AutoServiceDb>
    {
        private readonly DatabaseRepository _databaseRepository;
        private readonly DatabaseConnectionAction _connectionAction;

        public DbInitializer(DatabaseRepository databaseRepository, DatabaseConnectionAction connectionAction)
        {
            _databaseRepository = databaseRepository;
            _connectionAction = connectionAction;
        }

        public void InitializeDatabase(AutoServiceDb context)
        {
            switch (_connectionAction)
            {
                case DatabaseConnectionAction.Create:
                    _databaseRepository.Create(context);
                    break;
                case DatabaseConnectionAction.CreateIfNotExists:
                    _databaseRepository.CreateIfNotExists(context);
                    break;
                case DatabaseConnectionAction.Connect:
                    _databaseRepository.Connect(context);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_connectionAction), _connectionAction, null);
            }
        }
    }
}