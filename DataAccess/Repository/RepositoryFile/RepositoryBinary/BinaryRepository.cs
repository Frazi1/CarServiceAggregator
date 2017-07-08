using System.IO;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class BinaryRepository : FileRepository
    {
        public BinaryRepository(BinaryRepositorySettings settings)
            : base(settings)
        {
            if (settings.FileMode == FileMode.Open)
            {
                CustomersOrdersObject data = BinaryHelper.Load(FilePath);
                CustomersList = data.Customers.ToList();
                OrdersList = data.Orders.ToList();
                foreach (Order order in OrdersList)
                    order.Customer = CustomersList.FirstOrDefault(c => c.CustomerId == order.CustomerId);
            }
        }

        public override void SaveChanges()
        {
            try
            {
                CustomersOrdersObject coo = new CustomersOrdersObject
                {
                    Customers = CustomersList.ToArray(),
                    Orders = OrdersList.ToArray()
                };

                BinaryHelper.Save(FilePath, coo);
            }
            catch
            {
                throw;
            }
        }
    }
}