using System.Collections.Generic;
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
                var data = XmlHelper.Load(settings.FilePath);
                SetData(data);
            }
        }

        public override void SaveChanges()
        {
            CarsList = new List<Car>();
            foreach (Order order in OrdersList)
            {
                if (!CarsList.Contains(order.Car))
                    CarsList.Add(order.Car);
            }
            CustomersOrdersObject coo = new CustomersOrdersObject
            {
                Customers = CustomersList.ToArray(),
                Orders = OrdersList.ToArray(),
                Cars = CarsList.ToArray()
            };
            XmlHelper.Save(FilePath, coo);
        }

    }
}