using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Common;
using MySql.Data.Entity;
using DataAccess.Model;

namespace DataAccess.RepositoryDb
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class AutoServiceDb : DbContext
    {
        public AutoServiceDb(string connectionString)
            : base (connectionString)
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
