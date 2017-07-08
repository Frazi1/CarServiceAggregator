namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepositorySettings : RepositorySettings
    {
        public DatabaseRepositorySettings(string connectionString, DatabaseConnectionAction databaseConnectionAction)
        {
            ConnectionString = connectionString;
            DatabaseConnectionAction = databaseConnectionAction;
        }

        public string ConnectionString { get; }
        public DatabaseConnectionAction DatabaseConnectionAction { get; }
    }
}