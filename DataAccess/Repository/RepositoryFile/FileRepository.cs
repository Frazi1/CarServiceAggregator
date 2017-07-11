using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryFile
{
    public abstract class FileRepository : IRepository
    {
        protected FileRepository(FileRepositorySettings settings)
        {
            FilePath = settings.FilePath;
        }

        public string FilePath { get; protected set; }
        protected IList<Customer> CustomersList { get; set; } = new List<Customer>();
        protected IList<Order> OrdersList { get; set; } = new List<Order>();
        protected IList<Car> CarsList { get; set; } = new List<Car>();

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
    }
}