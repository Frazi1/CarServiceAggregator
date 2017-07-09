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
                CustomersOrdersObject data = XmlHelper.Load(settings.FilePath);
                CustomersList = data.Customers.ToList();
                OrdersList = data.Orders.ToList();
            }
        }

        public override void SaveChanges()
        {
            CustomersOrdersObject coo = new CustomersOrdersObject
            {
                Customers = CustomersList.ToArray(),
                Orders = OrdersList.ToArray()
            };
            XmlHelper.Save(FilePath, coo);
        }
    }
}