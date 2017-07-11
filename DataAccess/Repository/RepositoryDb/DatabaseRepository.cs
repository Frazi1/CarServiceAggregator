using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepository : IRepository
    {
        private readonly AutoServiceDb _db;

        public DatabaseRepository(DatabaseRepositorySettings settings)
        {
            _db = new AutoServiceDb(settings.ConnectionString);

            DbInitialize(settings);
        }

        public IEnumerable<Customer> Customers => _db.Customers;

        public IEnumerable<Order> Orders => _db.Orders;

        public IEnumerable<Car> Cars => _db.Cars;

        public void AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
        }

        public void AddOrder(Order order)
        {
            _db.Orders.Add(order);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        private void DbInitialize(DatabaseRepositorySettings settings)
        {
            switch (settings.DatabaseConnectionAction)
            {
                case DatabaseConnectionAction.Create:
                    if (_db.Database.Exists())
                        _db.Database.Delete();
                    _db.Database.Create();
                    break;
                case DatabaseConnectionAction.CreateIfNotExists:
                    _db.Database.CreateIfNotExists();
                    break;
                case DatabaseConnectionAction.Connect:
                    if (!_db.Database.Exists())
                        throw new DatabaseMissingException();
                    //Боремся с LazyLoading. Нужно подгрузить таблицу Cars из БД.
                    _db.Cars.Load();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}