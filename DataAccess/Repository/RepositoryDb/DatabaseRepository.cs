using System;
using System.Collections.Generic;
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

        private readonly ICollection<Customer> _customersStash;
        private readonly ICollection<Order> _ordersStash;

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
            _customersStash = new List<Customer>();
            _ordersStash = new List<Order>();
            ErrorHappened = false;
            DbAction(db => DbHelper.DbInitialize(db, settings.DatabaseConnectionAction));
        }

        private bool IsLoaded {
            get {
                return _customers != null
                       && _orders != null
                       && _cars != null;
            }
        }

        public bool ErrorHappened { get; set; }
        public string ErrorMessage { get; set; }

        //TODO: Remove
        public ICollection<Order> OrdersStash {
            get { return _ordersStash; }
        }

        //TODO: Remove
        public ICollection<Customer> CustomersStash {
            get { return _customersStash; }
        }

        public void AddCustomer(Customer customer)
        {
            _customersStash.Add(customer);
        }

        public void AddOrder(Order order)
        {
            _ordersStash.Add(order);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            /*if (!IsLoaded) */
            Load();
            return _customers;
        }

        public IEnumerable<Order> GetOrders()
        {
            //if (!IsLoaded)
            Load();
            return _orders;
        }

        public IEnumerable<Car> GetCars()
        {
            //if (!IsLoaded)
            Load();
            return _cars;
        }

        public void SaveChanges()
        {
            DbAction(action: db =>
            {
                if (_ordersStash.Any())
                    db.Orders.AddRange(_ordersStash);
                if (_customersStash.Any())
                    db.Customers.AddRange(_customersStash);
                db.SaveChanges();
            },
            finallyAction: db =>
                {
                    _ordersStash.Clear();
                    _customersStash.Clear();
                });


        }

        private void DbAction(Action<AutoServiceDb> action, Action<AutoServiceDb> finallyAction = null)
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
                    _handler.Handle(e)
                        .SetError(this)
                        .SetErrorMessage(this, e.Message);
                }
                finally
                {
                    finallyAction?.Invoke(db);
                }
            }
        }

        private TResult DbFunc<TResult>(Func<AutoServiceDb, TResult> func, Action<AutoServiceDb> finallyAction = null)
        {
            using (var db = new AutoServiceDb(_connectionString))
            {
                try
                {
                    //DbHelper.DbInitialize(db, connectionAction);
                    return func(db);
                }
                catch (Exception e)
                {
                    _handler.Handle(e)
                        .SetError(this)
                        .SetErrorMessage(this, e.Message);
                }
                finally
                {
                    finallyAction?.Invoke(db);
                }
                return default(TResult);
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