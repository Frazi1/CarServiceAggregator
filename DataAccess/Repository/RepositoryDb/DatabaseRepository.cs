using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.RepositoryDb
{
    public class DatabaseRepository : IRepository
    {
        private readonly AutoServiceDb db;

        public IEnumerable<Customer> Customers => db.Customers;
        public IEnumerable<Order> Orders => db.Orders;

        public DatabaseRepository(DatabaseRepositorySettings settings)
        {
            db = new AutoServiceDb(settings.ConnectionString);
        }

        public void AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
        }

        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
        }

        public Customer GetCustomer(int id) => db.Customers.Find(id);

        public Order GetOrder(int id) => db.Orders.Find(id);

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
