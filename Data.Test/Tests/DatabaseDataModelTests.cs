﻿using System.Linq;
using Data.Test.Base;
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
            Assert.IsTrue(Repository.Orders.Any());
            Assert.IsTrue(Repository.Customers.Any());
        }
    }
}