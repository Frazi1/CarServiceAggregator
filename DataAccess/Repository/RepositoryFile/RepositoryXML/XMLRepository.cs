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
                CustomersOrdersObject data = XmlHelper.Load(settings.FilePath);
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

        public override void SaveChanges()
        {
            CarsList = new List<Car>();
            foreach (Order order in OrdersList)
            {
                if(!CarsList.Contains(order.Car))
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