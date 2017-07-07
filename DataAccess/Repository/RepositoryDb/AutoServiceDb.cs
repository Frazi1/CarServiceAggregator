using System.Data.Common;
using System.Data.Entity;
using DataAccess.Model;
using MySql.Data.Entity;

namespace DataAccess.Repository.RepositoryDb
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AutoServiceDb : DbContext
    {
        public AutoServiceDb(string connectionString)
            : base(connectionString)
        {
        }

        public AutoServiceDb(DbConnection existingConnection, bool contextsOwnsConnection)
            : base(existingConnection, contextsOwnsConnection)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}