using System.Data.Entity.Validation;
using System.Linq;
using Data.Test.Base;
using DataAccess.Model;
using DataAccess.Repository.RepositoryDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Tests
{
    [TestClass]
    public class DatabaseDataModelTests : BaseDatabaseDataModelTest
    {
        [TestMethod]
        public void DatabaseRepositoryModelCreationTest()
        {
            Repository = new DatabaseRepository(
                new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create));

            AddTestDataToRepository();
            Repository.SaveChanges();
        }

        [TestMethod]
        public void DatabaseRepositoryModelLoadTest()
        {
            Repository = new DatabaseRepository(
                new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create));

            AddTestDataToRepository();
            Repository.SaveChanges();

            Repository = new DatabaseRepository(
                new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Connect));

            Assert.IsTrue(Repository.GetOrders().Any());
            Assert.IsTrue(Repository.GetCustomers().Any());
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void DatabaseRepositoryAddingIncorrentCustomerTest()
        {
            Repository = new DatabaseRepository(
                new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create));
            Customer incorrectCustomer = new Customer();
            Repository.AddCustomer(incorrectCustomer);
            Repository.SaveChanges();
            Assert.IsTrue(Repository.ErrorHappened);
        }

        [TestMethod]
        public void DatabaseRepositoryStashClearingWhenErrorTest()
        {
            DatabaseRepository dbRepository = new DatabaseRepository(
                new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create));
            Customer incorrectCustomer = new Customer();
            Order incorrectOrder = new Order();
            dbRepository.AddCustomer(incorrectCustomer);
            dbRepository.AddOrder(incorrectOrder);
            try
            {
                dbRepository.SaveChanges();
            }
            catch
            {
                // ignored
            }
            Assert.IsFalse(dbRepository.CustomersStash.Any());
            Assert.IsFalse(dbRepository.OrdersStash.Any());
            Assert.IsFalse(dbRepository.CarsStash.Any());
        }
    }
}