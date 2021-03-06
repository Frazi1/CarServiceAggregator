﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
using ExceptionHandling;

namespace DataAccess.Repository.RepositoryFile
{
    public abstract class FileRepository : IRepository
    {
        #region Constructors

        protected FileRepository(FileRepositorySettings settings, ILogger logger)
        {
            Logger = logger;
            FilePath = settings.FilePath;
            ErrorHappened = false;
        }

        #endregion

        #region IErrorReporter interface implementation

        public bool ErrorHappened { get; set; }

        #endregion

        #region Properties

        protected IList<Customer> CustomersList { get; set; }
        protected IList<Order> OrdersList { get; set; }
        protected IList<Car> CarsList { get; set; }

        protected ILogger Logger { get; }

        public string FilePath { get; protected set; }

        #endregion

        #region IRepository interface implementation

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

        #endregion

        #region Private methods

        private void Create()
        {
            CustomersList = new List<Customer>();
            OrdersList = new List<Order>();
            CarsList = new List<Car>();
        }

        private void LoadReferences()
        {
            try
            {
                foreach (Order order in OrdersList)
                {
                    order.Customer = CustomersList.First(c => c.CustomerId == order.CustomerId);
                    order.Car = CarsList.First(c => c.CarId == order.CarId);
                }

                foreach (Car car in CarsList)
                    car.Customer = CustomersList.First(c => c.CustomerId == car.CustomerId);
            }
            catch (InvalidOperationException e)
            {
                throw new FileCorruptedException("Скорее всего файл поврежден.", e);
            }
        }

        private void SetLoadedData(Tuple<Customer[], Order[], Car[]> data)
        {
            if (data == null) return;
            CustomersList = data.Item1.ToList();
            OrdersList = data.Item2.ToList();
            CarsList = data.Item3.ToList();

            try
            {
                LoadReferences();
            }
            catch (Exception e)
            {
                Logger.Log(e);
                Logger.SetError(this);
            }
        }

        #endregion

        #region Protected methods

        protected abstract Tuple<Customer[], Order[], Car[]> Load(string filePath);

        protected void Initialize(FileRepositoryMode fileRepositoryMode)
        {
            switch (fileRepositoryMode)
            {
                case FileRepositoryMode.Create:
                    Create();
                    break;
                case FileRepositoryMode.Open:
                    SetLoadedData(Load(FilePath));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileRepositoryMode), fileRepositoryMode, null);
            }
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
                car.CustomerId = CustomersList.First(c => car.Customer == c).CustomerId;
        }

        #endregion
    }
}