using System;
using System.Linq;
using DataAccess.Model;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class BinaryRepository : FileRepository
    {
        #region Constructors

        public BinaryRepository(BinaryRepositorySettings settings)
            : this(settings, new NullLogger())
        {
        }

        public BinaryRepository(BinaryRepositorySettings settings, ILogger logger)
            : base(settings, logger)
        {
            Initialize(settings.FileMode);
        }
        #endregion

        protected override Tuple<Customer[], Order[], Car[]> Load(string filePath)
        {
            try
            {
                return BinaryHelper.Load<Tuple<Customer[], Order[], Car[]>>(filePath);
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
                = new Tuple<Customer[], Order[], Car[]>(GetCustomers().ToArray(),
                GetOrders().ToArray(),
                GetCars().ToArray());

            try
            {
                BinaryHelper.Save(FilePath, tuple);
            }
            catch (Exception e)
            {
                Logger.Log(e);
                Logger.SetError(this);
            }
        }
    }
}