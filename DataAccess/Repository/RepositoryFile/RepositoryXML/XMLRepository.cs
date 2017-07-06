using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
using System.IO;

namespace DataAccess.RepositoryFile.RepositoryXML
{
    public sealed class XMLRepository : FileRepository
    {
        public XMLRepository(XMLRepositorySettings settings)
            : base(settings)
        {
            if (settings.FileMode == FileMode.Open)
            {
                var data = XMLHelper.Load(settings.FilePath);
                CustomersList = data.Customers.ToList();
                OrdersList = data.Orders.ToList();
            }
        }

        public override void SaveChanges()
        {
            var coo = new CustomersOrdersObject()
            {
                Customers = CustomersList.ToArray(),
                Orders = OrdersList.ToArray()
            };
            XMLHelper.Save(FilePath, coo);
        }
    }
}
