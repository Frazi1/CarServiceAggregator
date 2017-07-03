using System.Linq;
using DataAccess.Model;
using System.IO;

namespace DataAccess.RepositoryFile.RepositoryBinary
{
    public sealed class BinaryRepository : FileRepository
    {

        public BinaryRepository(BinaryRepositorySettings settings)
            : base(settings)
        {
            if (settings.FileMode == FileMode.Open)
            {
                var data = BinaryHelper.Load(FilePath);
                customers = data.Customers.ToList();
                orders = data.Orders.ToList();
            }
        }

        public override void SaveChanges()
        {
            try
            {
                var coo = new CustomersOrdersObject()
                {
                    Customers = customers.ToArray(),
                    Orders = orders.ToArray()
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
