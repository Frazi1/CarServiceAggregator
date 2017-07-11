using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryFile
{
    public abstract class FileRepository : IRepository
    {
        protected FileRepository(FileRepositorySettings settings)
        {
            CustomersList = new List<Customer>();
            OrdersList = new List<Order>();
            CarsList = new List<Car>();

            FilePath = settings.FilePath;
        }

        protected IList<Customer> CustomersList { get; set; }
        protected IList<Order> OrdersList { get; set; }
        protected IList<Car> CarsList { get; set; }

        public string FilePath { get; protected set; }

        public IEnumerable<Customer> Customers => CustomersList.AsEnumerable();
        public IEnumerable<Order> Orders => OrdersList.AsEnumerable();
        public IEnumerable<Car> Cars => CarsList.AsEnumerable();

        public void AddCustomer(Customer customer)
        {
            CustomersList.Add(customer);
        }

        public void AddOrder(Order order)
        {
            OrdersList.Add(order);
        }

        public abstract void SaveChanges();

        public virtual void SetData(CustomersOrdersObject data)
        {
            CustomersList = data.Customers.ToList();
            OrdersList = data.Orders.ToList();
            CarsList = data.Cars.ToList();
            foreach (Order order in OrdersList)
            {
                order.Customer = CustomersList.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                order.Car = CarsList.FirstOrDefault(c => c.CarId == order.CarId);
            }
        }
    }
}