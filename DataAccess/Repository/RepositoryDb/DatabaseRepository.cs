using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Model;
using ExceptionHandling;
using ExceptionHandling.Null;

namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseRepository : IRepository
    {
        private readonly IExceptionHandler _handler;
        private readonly string _connectionString;

        private IEnumerable<Customer> _customers;
        private IEnumerable<Order> _orders;
        private IEnumerable<Car> _cars;

        public DatabaseRepository(DatabaseRepositorySettings settings)
            : this(settings, new NullHandler())
        {
        }

        public DatabaseRepository(DatabaseRepositorySettings settings, IExceptionHandler handler)
        {
            _handler = handler;
            _connectionString = settings.ConnectionString;
            ErrorHappened = false;
            DbAction(db => DbHelper.DbInitialize(db,settings.DatabaseConnectionAction));
        }

        public bool ErrorHappened { get; set; }


        public void AddCustomer(Customer customer)
        {
            DbAction(db =>
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            });
        }

        public IEnumerable<Customer> GetCustomers()
        {
            if(_customers == null)
                Load();
            return _customers;
        }

        public IEnumerable<Order> GetOrders()
        {
            if(_orders == null)
                Load();
            return _orders;
        }

        public IEnumerable<Car> GetCars()
        {
            if(_cars == null)
               Load();
            return _cars;
        }

        public void AddOrder(Order order)
        {
            DbAction(db =>
            {
                db.Orders.Add(order);
                db.SaveChanges();
            });
        }

        public void SaveChanges()
        {
            //TODO : Что-то
            //try
            //{
            //    _db.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    _handler.Handle(e).SetError(this);
            //}
        }

        private void DbAction(Action<AutoServiceDb> action)
        {
            using (var db = new AutoServiceDb(_connectionString))
            {
                try
                {
                    //DbHelper.DbInitialize(db, connectionAction);
                    action(db);
                }
                catch (Exception e)
                {
                    _handler.Handle(e).SetError(this);
                }
            }
        }

        private TResult DbFunc<TResult>(Func<AutoServiceDb, TResult> func)
        {
            using (var db = new AutoServiceDb(_connectionString))
            {
                TResult result = default(TResult);
                try
                {
                    //DbHelper.DbInitialize(db, connectionAction);
                    return func(db);
                }
                catch (Exception e)
                {
                    _handler.Handle(e).SetError(this);
                }
                return result;
            }
        }

        private void Load()
        {
            DbAction(db =>
            {
                _orders = db.Orders.ToList();
                _customers = db.Customers.ToList();
                _cars = db.Cars.ToList();
            });
        }
    }
}