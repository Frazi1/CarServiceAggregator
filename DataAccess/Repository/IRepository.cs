using System.Collections.Generic;
using DataAccess.Model;

namespace DataAccess.Repository
{
    public interface IRepository
    {
        IEnumerable<Customer> Customers { get; }
        IEnumerable<Order> Orders { get; }

        void AddOrder(Order order);

        void AddCustomer(Customer customer);
        //Order GetOrder(int id);
        //Customer GetCustomer(int id);

        void SaveChanges();
    }
}