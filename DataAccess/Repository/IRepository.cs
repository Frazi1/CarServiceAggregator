using System.Collections.Generic;
using DataAccess.Model;
using ExceptionHandling;

namespace DataAccess.Repository
{
    public interface IRepository : IErrorReporter
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Order> GetOrders();
        IEnumerable<Car> GetCars();

        void AddOrder(Order order);
        void AddCustomer(Customer customer);
        void AddCar(Car car);

        void SaveChanges();
    }
}