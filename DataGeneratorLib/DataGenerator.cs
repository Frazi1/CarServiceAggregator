using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataGeneratorLib.ExtensionMethods;

namespace DataGeneratorLib
{
    public class DataGenerator
    {
        public DataGenerator(int customersCount, Random r)
        {
            InitializePaths();
            InitializeCollections();

            GenerateCustomers(customersCount, r);
            GenerateOrders(r);

            Orders = Orders.OrderBy(o => o.TaskStarted)
                .ToList();
        }

        #region Constants

        private const int MaxCustomerOrdersNumber = 10;
        private const int MinCarManufactureYear = 1950;
        private const int MinCustomerAge = 18;
        private const short MinTaskStartedYear = 2010;
        private const int MinOrderPrice = 1000;
        private const int MaxOrderPrice = 20000;
        private const int MaxOrderDays = 14;
        private const int MinEnginePower = 50;
        private const int MaxEnginePower = 300;

        private readonly Dictionary<string, string> _filePaths = new Dictionary<string, string>();

        #endregion

        #region Properties

        public List<Customer> Customers { get; } = new List<Customer>();
        public List<Order> Orders { get; } = new List<Order>();
        public List<Car> Cars { get; } = new List<Car>();

        private List<string> Surnames { get; set; }
        private List<string> Firstnames { get; set; }
        private List<string> Patronymics { get; set; }
        private List<string> CarBrands { get; set; }
        private List<string> CarModels { get; set; }
        private List<string> Transmissions { get; set; }
        private List<string> TaskNames { get; set; }
        private Dictionary<Customer, List<Car>> CustomersCars { get; set; }

        #endregion

        #region Initialization

        private void InitializePaths()
        {
            _filePaths.Add("surname", @"Data/surname.txt");
            _filePaths.Add("firstname", @"Data/firstname.txt");
            _filePaths.Add("patronymic", @"Data/patronymic.txt");
            _filePaths.Add("brands", @"Data/brands.txt");
            _filePaths.Add("tasks", @"Data/tasks.txt");
        }

        private void InitializeCollections()
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

            CustomersCars = new Dictionary<Customer, List<Car>>();
        }

        #endregion

        #region Generator methods

        private void GenerateOrders(Random r)
        {
            foreach (Customer customer in Customers)
            {
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
                        Customer = customer,
                        Car = selectedCar,
                        Price = r.Next(MinOrderPrice, MaxOrderPrice),
                        TaskName = TaskNames[r.Next(TaskNames.Count)],
                        TaskStarted = taskStarted,
                        TaskFinished = taskFinished
                    };
                    Orders.Add(order);
                    Cars.Add(selectedCar);
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

                Customers.Add(customer);

                int carNumber = r.Next(1, 3);
                var cars = new List<Car>();
                for (var i = 0; i < carNumber; i++)
                {
                    Car car = GenerateCar(r);
                    car.Customer = customer;
                    cars.Add(car);
                }
                CustomersCars.Add(customer, cars);
            }
        }

        private Car GenerateCar(Random r)
        {
            return new Car
            {
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
            bool isFinished = r.Next(0, 1000) > 200;
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

        #endregion
    }
}