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