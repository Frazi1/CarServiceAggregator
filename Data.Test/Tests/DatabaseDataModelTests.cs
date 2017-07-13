using System;
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
            SaveData();
        }

        [TestMethod]
        public void DatabaseRepositoryModelLoadTest()
        {
            SaveData();
            LoadData();
            Assert.IsTrue(Repository.GetOrders().Any());
            Assert.IsTrue(Repository.GetCustomers().Any());
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void DatabaseRepositoryAddingIncorrentCustomerTest()
        {
            Repository = new DatabaseRepository(new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create));
            var incorrectCustomer = new Customer();
            Repository.AddCustomer(incorrectCustomer);
            Repository.SaveChanges();
            Assert.IsTrue(Repository.ErrorHappened);
        }

        [TestMethod]
        public void DatabaseRepositoryStashClearingWhenErrorTest()
        {
            var dbRepository = new DatabaseRepository(new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create));
            var incorrectCustomer = new Customer();
            var incorrectOrder = new Order();
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
        }
    }
}