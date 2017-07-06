using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.RepositoryFile
{
    public abstract class FileRepository : IRepository
    {
        public string FilePath { get; protected set; }
        protected IList<Customer> CustomersList { get; set; } = new List<Customer>();
        protected IList<Order> OrdersList { get; set; } = new List<Order>();

        public IEnumerable<Customer> Customers => CustomersList.AsEnumerable();
        public IEnumerable<Order> Orders => OrdersList.AsEnumerable();

        public FileRepository(FileRepositorySettings settings)
        {
            FilePath = settings.FilePath;
        }

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
