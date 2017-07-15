using System;
using DataAccess.Model;
using DataAccess.Repository;
using DataGeneratorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Base
{
    public abstract class BaseDataModel
    {
        protected DataGenerator DataGenerator { get; private set; }
        protected IRepository Repository { get; set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            const int customersCount = 30;
            DataGenerator = new DataGenerator(customersCount, new Random());
        }

        protected void AddTestDataToRepository()
        {
            foreach (Customer customer in DataGenerator.Customers)
                Repository.AddCustomer(customer);
            foreach (Order order in DataGenerator.Orders)
                Repository.AddOrder(order);
            foreach (Car car in DataGenerator.Cars)
                Repository.AddCar(car);
        }
    }
}