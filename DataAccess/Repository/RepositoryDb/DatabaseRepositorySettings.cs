namespace DataAccess.RepositoryDb
{
    public class DatabaseRepositorySettings : RepositorySettings
    {
        public string ConnectionString { get; }

        public DatabaseRepositorySettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}