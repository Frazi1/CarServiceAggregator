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
        //TODO: Сделать кэширование данных

        #region Private fields

        private readonly ILogger _logger;
        private readonly string _connectionString;

        private readonly ICollection<Customer> _customersStash;
        private readonly ICollection<Order> _ordersStash;
        private readonly ICollection<Car> _carsStash;

        private IEnumerable<Customer> _customers;
        private IEnumerable<Order> _orders;
        private IEnumerable<Car> _cars;

        #endregion

        #region Constructors

        public DatabaseRepository(DatabaseRepositorySettings settings)
            : this(settings, new NullLogger())
        {
        }

        public DatabaseRepository(DatabaseRepositorySettings settings, ILogger logger)
        {
            _logger = logger;
            _connectionString = settings.ConnectionString;
            _customersStash = new List<Customer>();
            _carsStash = new List<Car>();
            _ordersStash = new List<Order>();
            ErrorHappened = false;
            Database.SetInitializer(new DbInitializer(this, settings.DatabaseConnectionAction));
            DbAction(context => context.Database.Initialize(force: true));
        }

        #endregion

        #region IErrorReporter interface implementation

        public bool ErrorHappened { get; set; }

        #endregion

        public IEnumerable<Order> OrdersStash {
            get { return _ordersStash; }
        }

        public IEnumerable<Customer> CustomersStash {
            get { return _customersStash; }
        }

        public IEnumerable<Car> CarsStash {
            get { return _carsStash; }
        }

        #region IRepository interface implementation

        public void AddCustomer(Customer customer)
        {
            _customersStash.Add(customer);
        }

        public void AddOrder(Order order)
        {
            _ordersStash.Add(order);
        }

        public void AddCar(Car car)
        {
            _carsStash.Add(car);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }


        public IEnumerable<Car> GetCars()
        {
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
                    _carsStash.Clear();
                });
        }

        #endregion

        #region DbActions

        private void DbAction(Action<AutoServiceDb> action, Action<AutoServiceDb> finallyAction = null)
        {
            using (var context = new AutoServiceDb(_connectionString))
            {
                DbAction(context, action, finallyAction);
            }
        }

        private void DbAction(AutoServiceDb context, Action<AutoServiceDb> action,
            Action<AutoServiceDb> finallyAction = null)
        {
            try
            {
                action(context);
            }
            catch (Exception e)
            {
                _logger.Log(e);
                _logger.SetError(this);
            }
            finally
            {
                finallyAction?.Invoke(context);
            }
        }

        private TResult DbFunc<TResult>(Func<AutoServiceDb, TResult> func, Action<AutoServiceDb> finallyAction = null)
        {
            using (var context = new AutoServiceDb(_connectionString))
            {
                return DbFunc(context, func, finallyAction);
            }
        }

        private TResult DbFunc<TResult>(AutoServiceDb context, Func<AutoServiceDb, TResult> func,
            Action<AutoServiceDb> finallyAction = null)
        {
            try
            {
                return func(context);
            }
            catch (Exception e)
            {
                _logger.Log(e);
                _logger.SetError(this);
            }
            finally
            {
                finallyAction?.Invoke(context);
            }
            return default(TResult);
        }

        #endregion

        #region Internal Methods

        internal void Load(AutoServiceDb context)
        {
            _orders = context.Orders.ToList();
            _customers = context.Customers.ToList();
            _cars = context.Cars.ToList();
        }

        internal void Connect(AutoServiceDb inputContext)
        {
            DbAction(inputContext, context =>
            {
                if (!context.Database.Exists())
                    throw new DatabaseMissingException("Базы данных не существует");
                Load(context);
            });
        }


        internal void CreateIfNotExists(AutoServiceDb inputContext)
        {
            DbAction(inputContext, context => { context.Database.CreateIfNotExists(); });
        }

        internal void Create(AutoServiceDb inputContext)
        {
            DbAction(inputContext, context =>
            {
                if (context.Database.Exists())
                    context.Database.Delete();
                context.Database.Create();
            });
        }

        #endregion
    }
}