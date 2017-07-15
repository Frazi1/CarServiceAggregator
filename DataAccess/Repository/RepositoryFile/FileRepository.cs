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
        public string ErrorMessage { get; set; }

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
                    SetLoadedData(Load(FilePath));
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

        public void AddCar(Car car)
        {
            CarsList.Add(car);
        }

        public abstract void SaveChanges();

        private void SetLoadedData(Tuple<Customer[], Order[], Car[]> data)
        {
            if (data == null) return;
            CustomersList = data.Item1.ToList();
            OrdersList = data.Item2.ToList();
            CarsList = data.Item3.ToList();

            LoadReferences();
        }

        protected void AssignIds()
        {
            for (int i = 0; i < CustomersList.Count; i++)
                CustomersList[i].CustomerId = i + 1;

            for (int i = 0; i < OrdersList.Count; i++)
                OrdersList[i].OrderId = i + 1;

            for (int i = 0; i < CarsList.Count; i++)
                CarsList[i].CarId = i + 1;
        }

        protected void SaveReferencesIds()
        {
            foreach (Order order in OrdersList)
            {
                order.CarId = CarsList.First(c => order.Car == c).CarId;
                order.CustomerId = CustomersList.First(c => order.Customer == c).CustomerId;
            }

            foreach (Car car in CarsList)
            {
                car.CustomerId = CustomersList.First(c => car.Customer == c).CustomerId;
            }
        }

        private void LoadReferences()
        {
            foreach (Order order in OrdersList)
            {
                order.Customer = CustomersList.First(c => c.CustomerId == order.CustomerId);
                order.Car = CarsList.First(c => c.CarId == order.CarId);
            }

            foreach (Car car in CarsList)
            {
                car.Customer = CustomersList.First(c => c.CustomerId == car.CustomerId);
            }
        }


    }
}