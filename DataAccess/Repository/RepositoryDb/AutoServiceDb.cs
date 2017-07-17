using System.Data.Entity;
using DataAccess.Model;
using MySql.Data.Entity;

namespace DataAccess.Repository.RepositoryDb
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AutoServiceDb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Cars { get; set; }

        public AutoServiceDb(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }   
    }
}