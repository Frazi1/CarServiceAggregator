using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.RepositoryFile
{
    public abstract class FileRepository : IRepository
    {
        public string FilePath { get; protected set; }
        protected IList<Customer> customers { get; set; } = new List<Customer>();
        protected IList<Order> orders { get; set; } = new List<Order>();

        public IEnumerable<Customer> Customers => customers.AsEnumerable();
        public IEnumerable<Order> Orders => orders.AsEnumerable();

        public FileRepository(FileRepositorySettings settings)
        {
            FilePath = settings.FilePath;
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public abstract void SaveChanges();
    }
}
