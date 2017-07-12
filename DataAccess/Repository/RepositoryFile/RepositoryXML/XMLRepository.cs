using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
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

        protected override CustomersOrdersObject Load(string filePath)
        {
            try
            {
             return XmlHelper.Load(filePath);
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
            CustomersOrdersObject coo = new CustomersOrdersObject
            {
                Customers = CustomersList.ToArray(),
                Orders = OrdersList.ToArray(),
                Cars = CarsList.ToArray()
            };
            try
            {
                XmlHelper.Save(FilePath, coo);
            }
            catch (Exception e)
            {
                _handler.Handle(e)
                    .SetError(this);
            }
        }
    }
}