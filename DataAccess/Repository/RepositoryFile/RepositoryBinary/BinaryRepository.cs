using System;
using System.Linq;
using DataAccess.Model;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class BinaryRepository : FileRepository
    {
        private readonly ILogger _logger;

        public BinaryRepository(BinaryRepositorySettings settings)
            : this(settings, new NullLogger())
        { }

        public BinaryRepository(BinaryRepositorySettings settings, ILogger logger)
            : base(settings)
        {
            _logger = logger;
            Initialize(settings.FileMode);
        }

        protected override Tuple<Customer[], Order[], Car[]> Load(string filePath)
        {
            try
            {
                return BinaryHelper.Load<Tuple<Customer[], Order[], Car[]>>(filePath);
            }
            catch (Exception e)
            {
                _logger.Log(e);
                _logger.SetError(this);
            }
            return null;
        }

        public override void SaveChanges()
        {
            AssignIds();
            SaveReferencesIds();

            var tuple 
                = new Tuple<Customer[], Order[], Car[]>(GetCustomers().ToArray(), GetOrders().ToArray(), GetCars().ToArray());

            try
            {
                BinaryHelper.Save(FilePath, tuple);
            }
            catch (Exception e)
            {
                _logger.Log(e);
                _logger.SetError(this);
            }
        }
    }
}