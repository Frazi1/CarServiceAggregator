using System.Collections.Generic;
using DataAccess.Model;
using ExceptionHandling;

namespace DataAccess.Repository
{
    public interface IRepository : IErrorReporter
    {
        IEnumerable<Customer> Customers { get; }
        IEnumerable<Order> Orders { get; }
        IEnumerable<Car> Cars { get; }

        void AddOrder(Order order);
        void AddCustomer(Customer customer);
        //Order GetOrder(int id);
        //Customer GetCustomer(int id);

        void SaveChanges();
    }
}