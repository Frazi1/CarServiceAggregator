using System.IO;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class XmlRepository : FileRepository
    {
        public XmlRepository(XmlRepositorySettings settings)
            : base(settings)
        {
            if (settings.FileMode == FileMode.Open)
            {
                CustomersOrdersObject data = XMLHelper.Load(settings.FilePath);
                CustomersList = data.Customers.ToList();
                OrdersList = data.Orders.ToList();
                foreach (Order order in OrdersList)
                    order.Customer = CustomersList.FirstOrDefault(c => c.CustomerId == order.CustomerId);
            }
        }

        public override void SaveChanges()
        {
            CustomersOrdersObject coo = new CustomersOrdersObject
            {
                Customers = CustomersList.ToArray(),
                Orders = OrdersList.ToArray()
            };
            XMLHelper.Save(FilePath, coo);
        }
    }
}