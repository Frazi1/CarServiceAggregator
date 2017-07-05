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
                customers = data.Customers.ToList();
                orders = data.Orders.ToList();
            }
        }

        public override void SaveChanges()
        {
            var coo = new CustomersOrdersObject()
            {
                Customers = customers.ToArray(),
                Orders = orders.ToArray()
            };
            XMLHelper.Save(FilePath, coo);
        }
    }
}
