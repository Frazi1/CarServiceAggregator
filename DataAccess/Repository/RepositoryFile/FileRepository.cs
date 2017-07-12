using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryFile
{
    public abstract class FileRepository : IRepository
    {
        protected FileRepository(FileRepositorySettings settings)
        {
            FilePath = settings.FilePath;
            ErrorHappened = false;
        }

        protected IList<Customer> CustomersList { get; set; }
        protected IList<Order> OrdersList { get; set; }
        protected IList<Car> CarsList { get; set; }

        public string FilePath { get; protected set; }
        public bool ErrorHappened { get; set; }

        public IEnumerable<Customer> GetCustomers()
        {
            return CustomersList.AsEnumerable();
        }

        public IEnumerable<Order> GetOrders()
        {
            return OrdersList.AsEnumerable();
        }

        public IEnumerable<Car> GetCars()
        {
            return CarsList.AsEnumerable();
        }

        private void Create()
        {
            CustomersList = new List<Customer>();
            OrdersList = new List<Order>();
            CarsList = new List<Car>();
        }

        protected abstract Tuple<Customer[], Order[], Car[]> Load(string filePath);

        protected void Initialize(FileMode fileMode)
        {
            switch (fileMode)
            {
                case FileMode.CreateNew:
                    throw new InvalidOperationException();
                case FileMode.Create:
                    Create();
                    break;
                case FileMode.Open:
                    SetData(Load(FilePath));
                    break;
                case FileMode.OpenOrCreate:
                    throw new InvalidOperationException();
                case FileMode.Truncate:
                    throw new InvalidOperationException();
                case FileMode.Append:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileMode), fileMode, null);
            }
        }


        public void AddCustomer(Customer customer)
        {
            CustomersList.Add(customer);
        }

        public void AddOrder(Order order)
        {
            OrdersList.Add(order);
        }

        public abstract void SaveChanges();

        public virtual void SetData(Tuple<Customer[], Order[], Car[]> data)
        {
            if(data == null) return;
            CustomersList = data.Item1.ToList();
            OrdersList = data.Item2.ToList();
            CarsList = data.Item3.ToList();
            foreach (Order order in OrdersList)
            {
                order.Customer = CustomersList.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                order.Car = CarsList.FirstOrDefault(c => c.CarId == order.CarId);
            }
        }
    }
}