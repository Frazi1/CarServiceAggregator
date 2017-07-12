using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
using DataAccess.MutableTuple;
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
                    .SetError(this);
            }
            return null;
        }

        public override void SaveChanges()
        {
            CarsList = new List<Car>();
            foreach (Order order in OrdersList)
                if (!CarsList.Contains(order.Car))
                    CarsList.Add(order.Car);

            var tuple 
                = new Tuple<Customer[], Order[], Car[]>(GetCustomers().ToArray(), GetOrders().ToArray(), GetCars().ToArray());

            try
            {
                BinaryHelper.Save(FilePath, tuple);
            }
            catch (Exception e)
            {
                _handler.Handle(e)
                    .SetError(this);
            }
        }
    }
}