using System.Collections.Generic;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepository : IRepository
    {
        private readonly AutoServiceDb _db;

        public DatabaseRepository(DatabaseRepositorySettings settings)
        {
            _db = new AutoServiceDb(settings.ConnectionString);
        }

        public IEnumerable<Customer> Customers => _db.Customers;
        public IEnumerable<Order> Orders => _db.Orders;

        public void AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
        }

        public void AddOrder(Order order)
        {
            _db.Orders.Add(order);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            return _db.Customers.Find(id);
        }

        public Order GetOrder(int id)
        {
            return _db.Orders.Find(id);
        }
    }
}