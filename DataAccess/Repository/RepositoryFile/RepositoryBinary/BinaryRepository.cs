using System;
using System.Linq;
using DataAccess.Model;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class BinaryRepository : FileRepository
    {
        private readonly IExceptionHandler _handler;

        public BinaryRepository(BinaryRepositorySettings settings)
            : this(settings, new NullHandler())
        { }

        public BinaryRepository(BinaryRepositorySettings settings, IExceptionHandler handler)
            : base(settings)
        {
            _handler = handler;
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
                _handler.Handle(e)
                    .SetError(this)
                    .SetErrorMessage(this, e.Message);
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
                _handler.Handle(e)
                    .SetError(this)
                    .SetErrorMessage(this, e.Message);
            }
        }
    }
}