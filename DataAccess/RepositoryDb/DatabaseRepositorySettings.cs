namespace DataAccess.RepositoryDb
{
    public class DatabaseRepositorySettings : RepositorySettings
    {
        public string ConnectionString { get; set; }

        public DatabaseRepositorySettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}