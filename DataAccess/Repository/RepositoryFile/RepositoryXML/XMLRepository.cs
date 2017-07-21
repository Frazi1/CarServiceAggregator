using System;
using System.Linq;
using DataAccess.Model;
using DataAccess.MutableTuple;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class XmlRepository : FileRepository
    {
        public XmlRepository(XmlRepositorySettings settings)
            : this(settings, new NullLogger())
        {
        }

        public XmlRepository(XmlRepositorySettings settings, ILogger logger)
            : base(settings, logger)
        {
            Initialize(settings.FileMode);
        }

        protected override Tuple<Customer[], Order[], Car[]> Load(string filePath)
        {
            try
            {
                return XmlHelper<MutableTuple<Customer[], Order[], Car[]>>.Load(filePath);
            }
            catch (Exception e)
            {
                Logger.Log(e);
                Logger.SetError(this);
            }
            return null;
        }

        public override void SaveChanges()
        {
            AssignIds();
            SaveReferencesIds();
            var tuple
                = new MutableTuple<Customer[], Order[], Car[]>
                {
                    Item1 = GetCustomers().OrderBy(c => c.CustomerId).ToArray(),
                    Item2 = GetOrders().OrderBy(o => o.OrderId).ToArray(),
                    Item3 = GetCars().OrderBy(c => c.CarId).ToArray()
                };
            try
            {
                XmlHelper<MutableTuple<Customer[], Order[], Car[]>>.Save(FilePath, tuple);
            }
            catch (Exception e)
            {
                Logger.Log(e);
                Logger.SetError(this);
            }
        }
    }
}