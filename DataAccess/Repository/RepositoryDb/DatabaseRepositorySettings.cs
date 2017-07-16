namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepositorySettings : RepositorySettings
    {
        public DatabaseRepositorySettings(string connectionString, DatabaseConnectionAction databaseConnectionAction)
        {
            ConnectionString = connectionString;
            DatabaseConnectionAction = databaseConnectionAction;
        }

        /// <summary>
        /// Позволяет просмотреть текущую строку, которая используется для соединения с базой данных.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// Позволяет узнать, какое действие будет совершено при подключении к базе данных.
        /// </summary>
        public DatabaseConnectionAction DatabaseConnectionAction { get; }
    }
}