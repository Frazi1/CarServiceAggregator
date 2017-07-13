﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataGeneratorLib.ExtensionMethods;

namespace DataGeneratorLib
{
    public class DataGenerator
    {
        private const int MaxCustomerOrdersNumber = 10;
        private const int MinCarManufactureYear = 1950;
        private const int MinCustomerAge = 18;
        private const short MinTaskStartedYear = 2010;
        private const int MinOrderPrice = 1000;
        private const int MaxOrderPrice = 20000;
        private const int MaxOrderDays = 14;
        private const int MinEnginePower = 50;
        private const int MaxEnginePower = 300;

        private static int _carsGeneratedCount = 1;

        private readonly Dictionary<string, string> _filePaths = new Dictionary<string, string>();

        public readonly List<Customer> Customers = new List<Customer>();
        public readonly List<Order> Orders = new List<Order>();


        public DataGenerator(bool setId, int customersCount, Random r)
        {
            InitializePaths();
            Initialize();
            SetId = setId;

            GenerateCustomers(customersCount, r);
            GenerateOrders(r);

            var id = 1;
            //Orders = Orders.Shuffle()
            //    .Select(o => new Order
            //    {
            //        OrderId = id++,
            //        Car = o.Car,
            //        Customer = o.Customer,
            //        CustomerId = o.CustomerId,
            //        CarId = o.CarId,
            //        Price = o.Price,
            //        TaskFinished = o.TaskFinished,
            //        TaskName = o.TaskName,
            //        TaskStarted = o.TaskStarted
            //    })
            //    .ToList();
            //Orders = Orders.Shuffle()
            //    .Select(o =>
            //    {
            //        o.OrderId = id++;
            //        return o;
            //    })
            //    .ToList();
            Orders = Orders.OrderBy(o => o.TaskStarted)
                .Select(o =>
                {
                    o.OrderId = id++;
                    return o;
                })
                .ToList();
        }

        private List<string> Surnames { get; set; }
        private List<string> Firstnames { get; set; }
        private List<string> Patronymics { get; set; }
        private List<string> CarBrands { get; set; }
        private List<string> CarModels { get; set; }
        private List<string> Transmissions { get; set; }
        private List<string> TaskNames { get; set; }
        private Dictionary<Customer, List<Car>> CustomersCars { get; } = new Dictionary<Customer, List<Car>>();

        public bool SetId { get; set; }


        private void InitializePaths()
        {
            _filePaths.Add("surname", @"Data/surname.txt");
            _filePaths.Add("firstname", @"Data/firstname.txt");
            _filePaths.Add("patronymic", @"Data/patronymic.txt");
            _filePaths.Add("brands", @"Data/brands.txt");
            _filePaths.Add("tasks", @"Data/tasks.txt");
        }

        private void Initialize()
        {
            Surnames = Parser.ParseLines(_filePaths["surname"]);
            Firstnames = Parser.ParseAllTextWithCommas(_filePaths["firstname"]);
            Patronymics = Parser.ParseLines(_filePaths["patronymic"]);
            CarBrands = Parser.ParseLines(_filePaths["brands"]);
            CarModels = new List<string>();
            for (var i = 0; i < 10; i++)
                CarModels.Add($"Model{i}");

            TaskNames = Parser.ParseLines(_filePaths["tasks"]);
            Transmissions = new List<string> {"Автомат", "Вариатор", "Механическая"};
        }

        private void GenerateOrders(Random r)
        {
            var currentId = 1;

            foreach (Customer customer in Customers)
            {
                var customerId = customer.CustomerId;
                //Customer customer = Customers.First(c => c.CustomerId == customerId);
                var customerCars = CustomersCars[customer];

                for (var j = 0; j < r.Next(MaxCustomerOrdersNumber); j++)
                {
                    Car selectedCar = customerCars[r.Next(customerCars.Count)];

                    DateTime taskStarted;
                    DateTime? taskFinished;
                    GenerateTaskStartedAndFinished(r, customer, selectedCar.ManufactureYear, out taskStarted,
                        out taskFinished);

                    Order order = new Order
                    {
                        OrderId = currentId++,
                        CustomerId = customerId,
                        Car = selectedCar,
                        CarId = selectedCar.CarId,
                        Price = r.Next(MinOrderPrice, MaxOrderPrice),
                        TaskName = TaskNames[r.Next(TaskNames.Count)],
                        TaskStarted = taskStarted,
                        TaskFinished = taskFinished
                    };
                    //if (SetId)
                    //order.OrderId = i + 1;
                    Orders.Add(order);
                }
            }
        }

        private void GenerateCustomers(int count, Random r)
        {
            for (var j = 0; j < count; j++)
            {
                StringBuilder phone = new StringBuilder();
                phone.Append("8");
                for (var i = 0; i < 10; i++)
                    phone.Append(r.Next(10));
                Customer customer = new Customer
                {
                    Surname = Surnames[r.Next(Surnames.Count)],
                    FirstName = Firstnames[r.Next(Firstnames.Count)],
                    Patronymic = Patronymics[r.Next(Patronymics.Count)],
                    BirthYear = (short) r.Next(DateTime.Now.Year - 80, DateTime.Now.Year - 18),
                    PhoneNumber = phone.ToString()
                };

                if (SetId)
                    customer.CustomerId = j + 1;
                Customers.Add(customer);

                var carNumber = r.Next(1, 3);
                var cars = new List<Car>();
                for (var i = 0; i < carNumber; i++)
                    cars.Add(GenerateCar(r));
                CustomersCars.Add(customer, cars);
            }
        }

        private Car GenerateCar(Random r)
        {
            return new Car
            {
                CarId = _carsGeneratedCount++,
                CarModel = CarModels[r.Next(CarModels.Count)],
                CarBrand = CarBrands[r.Next(CarBrands.Count)],
                ManufactureYear = (short) r.Next(MinCarManufactureYear, DateTime.Now.Year),
                TransmissionType = Transmissions[r.Next(Transmissions.Count)],
                EnginePower = r.Next(MinEnginePower, MaxEnginePower)
            };
        }

        private static void GenerateTaskStartedAndFinished(Random r, Customer customer, short manufactureYear,
            out DateTime taskStarted, out DateTime? taskFinished)
        {
            var isFinished = r.Next(0, 1000) > 200;
            taskFinished = null;
            if (isFinished)
            {
                taskStarted = r.NextDateTime(new DateTime(
                        Math.Max(customer.BirthYear + MinCustomerAge, Math.Max(MinTaskStartedYear, manufactureYear)),
                        1, 1),
                    DateTime.Now);
                taskFinished = taskStarted.AddDays(r.Next(0, MaxOrderDays))
                    .AddHours(r.Next(2, 12))
                    .AddMinutes(r.Next(0, 59))
                    .AddSeconds(r.Next(0, 59));
            }
            else
            {
                taskStarted = DateTime.Now.AddDays(-r.Next(0, 14))
                    .AddHours(-r.Next(2, 12))
                    .AddMinutes(-r.Next(0, 59))
                    .AddSeconds(-r.Next(0, 59));
            }
        }
    }
}