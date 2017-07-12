using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Model;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepository : IRepository
    {
        private readonly AutoServiceDb _db;
        private readonly IExceptionHandler _handler;

        public DatabaseRepository(DatabaseRepositorySettings settings)
            : this(settings, new NullHandler())
        { }

        public DatabaseRepository(DatabaseRepositorySettings settings, IExceptionHandler handler)
        {
            _handler = handler;
            ErrorHappened = false;
            _db = new AutoServiceDb(settings.ConnectionString);

            DbInitialize(settings);
        }

        public bool ErrorHappened { get; set; }

        public IEnumerable<Customer> GetCustomers()
        {
            return _db.Customers;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _db.Orders;
        }

        public IEnumerable<Car> GetCars()
        {
            return _db.Cars;
        }

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
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                _handler.Handle(e).SetError(this);
            }
        }

        private void DbInitialize(DatabaseRepositorySettings settings)
        {
            try
            {
                switch (settings.DatabaseConnectionAction)
                {
                    case DatabaseConnectionAction.Create:
                        Create();
                        break;
                    case DatabaseConnectionAction.CreateIfNotExists:
                        CreateIfNotExists();
                        break;
                    case DatabaseConnectionAction.Connect:
                        Connect();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                _handler.Handle(e).SetError(this);
            }
        }

        private void Connect()
        {
            if (!_db.Database.Exists())
                throw new DatabaseMissingException("Не удалось подключится к базе данных");
            //Боремся с LazyLoading. Нужно подгрузить таблицу Cars из БД.
            _db.Cars.Load();
        }

        private void CreateIfNotExists()
        {
            _db.Database.CreateIfNotExists();
        }

        private void Create()
        {
            if (_db.Database.Exists())
                _db.Database.Delete();
            _db.Database.Create();
        }
    }
}