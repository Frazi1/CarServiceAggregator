using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;

namespace DataGenerator
{
    class Program
    {
        private static List<string> Surnames { get; set; }
        private static List<string> Firstnames { get; set; }
        private static List<string> Patronymics { get; set; }

        private static List<string> CarBrands { get; set; }
        private static List<string> CarModels { get; set; }
        private static List<string> Transmissions { get; set; }
        private static List<string> TaskNames { get; set; }

        private static List<Customer> Customers = new List<Customer>();
        private static List<Order> Orders = new List<Order>();

        static void Main(string[] args)
        {
            Initialize();

            Random r = new Random();


            Console.WriteLine("Number Customers");
            uint count_customers = uint.Parse(Console.ReadLine());
            Console.WriteLine("Number orders");
            uint count_orders = uint.Parse(Console.ReadLine());

            for (int i = 0; i < count_customers; i++)
            {
                var customer = GenerateCustomer(r);
                customer.CustomerId = i + 1;
                //customer.FirstName = "Test3";
                Customers.Add(customer);
            }

            for (int i = 0; i < count_orders; i++)
            {
                var order = GenerateOrder(r);
                order.OrderId = i + 1;
                Orders.Add(order);
            }

            const string connectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=new_autoservicedb1;";
            IRepository repo;
            //repo = new XmlRepository(new XmlRepositorySettings("AutoService3.xml", FileMode.Create));
            //repo = new BinaryRepository(new DataAccess.RepositoryFile.FileRepositorySettings("AutoService.dat", FileMode.Create));
            repo = new DatabaseRepository(new DatabaseRepositorySettings(connectionString));

            foreach (var item in Customers)
            {
                repo.AddCustomer(item);
            }
            foreach (var item in Orders)
            {
                repo.AddOrder(item);
            }
            repo.SaveChanges();

        }

        private static void Initialize()
        {
            ReadSurnames();
            ReadFirstNames();
            ReadPatronymics();
            ReadCarBrands();
            ReadCarModels();
            ReadTaskNames();
            ReadTransmissions();
        }

        private static Order GenerateOrder(Random r)
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
            return order;
        }

        private static Customer GenerateCustomer(Random r)
        {
            StringBuilder phone = new StringBuilder();
            phone.Append("8");
            for (int i = 0; i < 10; i++)
                phone.Append(r.Next(10));
            return new Customer
            {
                Surname = Surnames[r.Next(Surnames.Count)],
                FirstName = Firstnames[r.Next(Firstnames.Count)],
                Patronymic = Patronymics[r.Next(Patronymics.Count)],
                BirthYear = (short)r.Next(1950, 1998),
                PhoneNumber = phone.ToString()
            };
        }

        private static void ReadPatronymics()
        {
            using (StreamReader s = new StreamReader("patronymic.txt", Encoding.GetEncoding(1251)))
            {
                Patronymics = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        private static void ReadFirstNames()
        {
            using (StreamReader s = new StreamReader("firstname.txt", Encoding.GetEncoding(1251)))
            {
                Firstnames = s.ReadToEnd().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        private static void ReadSurnames()
        {
            using (StreamReader s = new StreamReader("surname.txt", Encoding.GetEncoding(1251)))
            {
                Surnames = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        private static void ReadCarBrands()
        {
            using (StreamReader s = new StreamReader("brands.txt", Encoding.GetEncoding(1251)))
            {
                CarBrands = s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        private static void ReadCarModels()
        {
            CarModels = new List<string>();
            for (int i = 0; i < 10; i++)
                CarModels.Add($"Model{i}");
        }

        private static void ReadTransmissions()
        {
            Transmissions = new List<string> { "Автомат", "Вариатор", "Механическая" };
        }

        private static void ReadTaskNames()
        {
            using (StreamReader s = new StreamReader("tasks.txt", Encoding.GetEncoding(1251)))
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
