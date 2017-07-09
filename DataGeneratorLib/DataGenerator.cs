using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataGeneratorLib.ExtensionMethods;

namespace DataGeneratorLib
{
    public class DataGenerator
    {

        //TODO: Несколько заказов с одной машиной. Несколько машин у одного заказчика.

        const int CarsAddtition = 30;

        public List<Customer> Customers = new List<Customer>();
        public List<Order> Orders = new List<Order>();

        protected Dictionary<string, string> FilePaths = new Dictionary<string, string>();

        public DataGenerator(bool setId, int customersCount, int ordersCount, Random r)
        {
            InitializePaths();
            Initialize();
            SetId = setId;

            GenerateCars(customersCount + CarsAddtition, r);
            GenerateCustomers(customersCount, r);
            GenerateOrders(ordersCount, r);
        }


        public bool SetId { get; set; }

        protected List<Car> Cars { get; set; } = new List<Car>();

        protected List<string> Surnames { get; set; }
        protected List<string> Firstnames { get; set; }
        protected List<string> Patronymics { get; set; }
        protected List<string> CarBrands { get; set; }
        protected List<string> CarModels { get; set; }
        protected List<string> Transmissions { get; set; }
        protected List<string> TaskNames { get; set; }

        private void InitializePaths()
        {
            FilePaths.Add("surname", @"Data/surname.txt");
            FilePaths.Add("firstname", @"Data/firstname.txt");
            FilePaths.Add("patronymic", @"Data/patronymic.txt");
            FilePaths.Add("brands", @"Data/brands.txt");
            FilePaths.Add("tasks", @"Data/tasks.txt");
        }

        private void Initialize()
        {
            Surnames = Parser.ReadSurnames(FilePaths["surname"]);
            Firstnames = Parser.ReadFirstNames(FilePaths["firstname"]);
            Patronymics = Parser.ReadPatronymics(FilePaths["patronymic"]);
            CarBrands = Parser.ReadCarBrands(FilePaths["brands"]);
            CarModels = Parser.ReadCarModels(null);
            TaskNames = Parser.ReadTaskNames(FilePaths["tasks"]);
            Transmissions = Parser.ReadTransmissions(null);
        }

        protected void GenerateOrders(int count, Random r)
        {
            for (var i = 0; i < count; i++)
            {
                var selectedCar = Cars[r.Next(Cars.Count)];
                var customerId = Customers[r.Next(Customers.Count)].CustomerId;
                Customer customer = Customers.First(c => c.CustomerId == customerId);
                var manufactureYear = (short)r.Next(1950, 2017);

                GenerateTaskStartedAndFinished(r, customer, manufactureYear, out DateTime taskStarted,
                    out DateTime? taskFinished);

                Order order = new Order
                {
                    CustomerId = customerId,
                    CarBrand = selectedCar.CarBrand,
                    CarModel = selectedCar.CarModel,
                    EnginePower = selectedCar.EnginePower,
                    ManufactureYear = selectedCar.ManufactureYear,
                    TransmissionType = selectedCar.TransmissionType,
                    Price = r.Next(1000, 20000),
                    TaskName = TaskNames[r.Next(TaskNames.Count)],
                    TaskStarted = taskStarted,
                    TaskFinished = taskFinished
                };
                if (SetId)
                    order.OrderId = i + 1;
                Orders.Add(order);
            }
        }

        protected void GenerateCustomers(int count, Random r)
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
                    BirthYear = (short)r.Next(DateTime.Now.Year - 80, DateTime.Now.Year - 18),
                    PhoneNumber = phone.ToString()
                };

                if (SetId)
                    customer.CustomerId = j + 1;
                Customers.Add(customer);
            }
        }

        protected void GenerateCars(int count, Random r)
        {
            for (int i = 0; i < count; i++)
            {
                Cars.Add(new Car
                {
                    CarModel = CarModels[r.Next(CarModels.Count)],
                    CarBrand = CarBrands[r.Next(CarBrands.Count)],
                    ManufactureYear = (short) r.Next(1950, DateTime.Now.Year),
                    TransmissionType = Transmissions[r.Next(Transmissions.Count)],
                    EnginePower = r.Next(50, 300)
                });
            }
        }

        private static void GenerateTaskStartedAndFinished(Random r, Customer customer, short manufactureYear,
            out DateTime taskStarted, out DateTime? taskFinished)
        {
            var isFinished = r.Next(0, 1000) > 200;
            taskFinished = null;
            if (isFinished)
            {
                taskStarted = r.NextDateTime(new DateTime(Math.Max(customer.BirthYear + 18, manufactureYear), 1, 1),
                    DateTime.Now);
                taskFinished = taskStarted.AddDays(r.Next(0, 14))
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

    public class Car
    {
        public string CarModel { get; set; }
        public string CarBrand { get; set; }
        public short ManufactureYear { get; set; }
        public string TransmissionType { get; set; }
        public int EnginePower { get; set; }
    }
}