using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
using DataAccess.MutableTuple;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class XmlRepository : FileRepository
    {
        private readonly IExceptionHandler _handler;

        public XmlRepository(XmlRepositorySettings settings)
            : this(settings, new NullHandler())
        { }

        public XmlRepository(XmlRepositorySettings settings, IExceptionHandler handler)
            : base(settings)
        {
            _handler = handler;
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
                = new MutableTuple<Customer[], Order[], Car[]>
                {
                    Item1 = Customers.ToArray(),
                    Item2 = Orders.ToArray(),
                    Item3 = Cars.ToArray()
                };
            try
            {
                XmlHelper<MutableTuple<Customer[], Order[], Car[]>>.Save(FilePath, tuple);
            }
            catch (Exception e)
            {
                _handler.Handle(e)
                    .SetError(this);
            }
        }
    }
}