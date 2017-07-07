namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepositorySettings : RepositorySettings
    {
        public DatabaseRepositorySettings(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}