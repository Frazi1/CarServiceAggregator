using System.Collections.Generic;
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
                CustomersOrdersObject data = BinaryHelper.Load(settings.FilePath);
                SetData(data);
            }
        }

        public override void SaveChanges()
        {
            CarsList = new List<Car>();
            foreach (Order order in OrdersList)
                if (!CarsList.Contains(order.Car))
                    CarsList.Add(order.Car);

            CustomersOrdersObject coo = new CustomersOrdersObject
            {
                Customers = CustomersList.ToArray(),
                Orders = OrdersList.ToArray(),
                Cars = CarsList.ToArray()
            };

            BinaryHelper.Save(FilePath, coo);
        }
    }
}