using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataAccess.Model;

namespace DataGeneratorLib
{
    public class DataGenerator
    {
        protected List<string> Surnames { get; set; }
        protected List<string> Firstnames { get; set; }
        protected List<string> Patronymics { get; set; }
        protected List<string> CarBrands { get; set; }
        protected List<string> CarModels { get; set; }
        protected List<string> Transmissions { get; set; }
        protected List<string> TaskNames { get; set; }

        protected Dictionary<string, string> FilePaths = new Dictionary<string, string>();

        public List<Customer> Customers = new List<Customer>();
        public List<Order> Orders = new List<Order>();

        

        public DataGenerator()
        {
            InitializePaths();
            Initialize();
        }

        private void InitializePaths()
        {
            FilePaths.Add("surname", @"Data/surname.txt");
            FilePaths.Add("firstname", @"Data/firstname.txt");
            FilePaths.Add("patronymic", @"Data/patronymic.txt");
            FilePaths.Add("brands", @"Data/brands.txt");
            FilePaths.Add("tasks", @"Data/tasks.txt");

        }

        public void Initialize()
        {
            ReadSurnames();
            ReadFirstNames();
            ReadPatronymics();
            ReadCarBrands();
            ReadCarModels();
            ReadTaskNames();
            ReadTransmissions();
        }

        public void GenerateOrder(int count, Random r)
        {
            for (int i = 0; i < count; i++)
            {
                var order = new Order
                {
                    CarBrand = CarBrands[r.Next(CarBrands.Count)],
                    CarModel = CarModels[r.Next(CarModels.Count)],
                    CustomerId = Customers[r.Next(Customers.Count)].CustomerId,
                    EnginePower = r.Next(50, 300),
                    ManufactureYear = (short)r.Next(1950, 2017),
                    Price = r.Next(1000, 20000),
                    TransmissionType = Transmissions[r.Next(Transmissions.Count)],
                    TaskName = TaskNames[r.Next(TaskNames.Count)],
                    TaskStarted = DateTime.Now,
                    TaskFinished = DateTime.Now
                };
                Orders.Add(order);
            }
        }

        public void GenerateCustomer(int count, Random r)
        {
            for (int j = 0; j < count; j++)
            {
                StringBuilder phone = new StringBuilder();
                phone.Append("8");
                for (int i = 0; i < 10; i++)
                    phone.Append(r.Next(10));
                var customer = new Customer
                {
                    Surname = Surnames[r.Next(Surnames.Count)],
                    FirstName = Firstnames[r.Next(Firstnames.Count)],
                    Patronymic = Patronymics[r.Next(Patronymics.Count)],
                    BirthYear = (short)r.Next(1950, 1998),
                    PhoneNumber = phone.ToString()
                };

                Customers.Add(customer);
            }
        }

        protected void ReadPatronymics()
        {
            using (StreamReader s = new StreamReader(FilePaths["patronymic"], Encoding.GetEncoding(1251)))
            {
                Patronymics = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        protected void ReadFirstNames()
        {
            using (StreamReader s = new StreamReader(FilePaths["firstname"], Encoding.GetEncoding(1251)))
            {
                Firstnames = s.ReadToEnd().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        protected void ReadSurnames()
        {
            using (StreamReader s = new StreamReader(FilePaths["surname"], Encoding.GetEncoding(1251)))
            {
                Surnames = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        protected void ReadCarBrands()
        {
            using (StreamReader s = new StreamReader(FilePaths["brands"], Encoding.GetEncoding(1251)))
            {
                CarBrands = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        protected void ReadCarModels()
        {
            CarModels = new List<string>();
            for (int i = 0; i < 10; i++)
                CarModels.Add($"Model{i}");
        }

        protected void ReadTransmissions()
        {
            Transmissions = new List<string> { "Автомат", "Вариатор", "Механическая" };
        }

        protected void ReadTaskNames()
        {
            using (StreamReader s = new StreamReader(FilePaths["tasks"], Encoding.GetEncoding(1251)))
            {
                TaskNames = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }
    }
}
