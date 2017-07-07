using DataAccess;
using DataAccess.Model;
using DataAccess.RepositoryDb;
using DataAccess.RepositoryFile.RepositoryBinary;
using DataAccess.RepositoryFile.RepositoryXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ReadSurnames();
            ReadFirstNames();
            ReadPatronymics();
            ReadCarBrands();
            ReadCarModels();
            ReadTaskNames();
            ReadTransmissions();

            Random r = new Random();


            Console.WriteLine("Number Customers");
            uint count_customers = uint.Parse(Console.ReadLine());
            Console.WriteLine("Number orders");
            uint count_orders = uint.Parse(Console.ReadLine());

            for (int i = 0; i < count_customers; i++)
            {
                var customer = GenerateCustomer(r);
                customer.ID = i + 1;
                customer.FirstName = "Test3";
                Customers.Add(customer);
            }

            for (int i = 0; i < count_orders; i++)
            {
                var order = GenerateOrder(r);
                order.ID = i + 1;
                Orders.Add(order);
            }

            const string connectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";
            IRepository repo;
            repo = new XmlRepository(new XmlRepositorySettings("AutoService3.xml", FileMode.Create));
            //repo = new BinaryRepository(new DataAccess.RepositoryFile.FileRepositorySettings("AutoService.dat", FileMode.Create));
            //repo = new DatabaseRepository(new DatabaseRepositorySettings(connectionString));

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

        private static Order GenerateOrder(Random r)
        {
            var order = new Order()
            {
                CarBrand = CarBrands[r.Next(CarBrands.Count)],
                CarModel = CarModels[r.Next(CarModels.Count)],
                CustomerID = Customers[r.Next(Customers.Count)].ID,
                EnginePower = r.Next(50, 300),
                ManufactureYear = r.Next(1950, 2017),
                Price = r.Next(1000, 20000),
                Transmission = Transmissions[r.Next(Transmissions.Count)],
                TaskName = TaskNames[r.Next(TaskNames.Count)],
                TaskStarted = DateTime.Now,
                TaskFinished = DateTime.Now,
            };
            return order;
        }

        private static Customer GenerateCustomer(Random r)
        {
            StringBuilder phone = new StringBuilder();
            phone.Append("8");
            for (int i = 0; i < 10; i++)
                phone.Append(r.Next(10));
            return new Customer()
            {
                Surname = Surnames[r.Next(Surnames.Count)],
                FirstName = Firstnames[r.Next(Firstnames.Count)],
                Patronymic = Patronymics[r.Next(Patronymics.Count)],
                BirthYear = r.Next(1950, 1998),
                PhoneNumber = phone.ToString()
            };
        }

        private static void ReadPatronymics()
        {
            StreamReader s = new StreamReader("patronymic.txt", Encoding.GetEncoding(1251));
            Patronymics = s.ReadToEnd()
                .Replace('\r', ' ')
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(str => str.Trim())
                .ToList();
            //Patronymics = File.ReadAllLines("patronymic.txt").ToList();
        }

        private static void ReadFirstNames()
        {
            StreamReader s = new StreamReader("firstname.txt", Encoding.GetEncoding(1251));
            Firstnames = s.ReadToEnd().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private static void ReadSurnames()
        {
            //Surnames = File.ReadLines("surname.txt").ToList();
            StreamReader s = new StreamReader("surname.txt", Encoding.GetEncoding(1251));
            Surnames = s.ReadToEnd()
                .Replace('\r', ' ')
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(str => str.Trim())
                .ToList();
        }

        private static void ReadCarBrands()
        {
            StreamReader s = new StreamReader("brands.txt", Encoding.GetEncoding(1251));
            CarBrands = s.ReadToEnd()
                .Replace('\r', ' ')
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(str => str.Trim())
                .ToList();
            //CarBrands = File.ReadAllLines("brands.txt")
            //    .ToList();
        }

        private static void ReadCarModels()
        {
            CarModels = new List<string>();
            for (int i = 0; i < 10; i++)
                CarModels.Add($"Model{i}");
        }

        private static void ReadTransmissions()
        {
            Transmissions = new List<string>();
            Transmissions.Add("Автомат");
            Transmissions.Add("Вариатор");
            Transmissions.Add("Механическая");
        }

        private static void ReadTaskNames()
        {
            StreamReader s = new StreamReader("tasks.txt", Encoding.GetEncoding(1251));
            TaskNames = s.ReadToEnd()
                .Replace('\r', ' ')
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(str => str.Trim())
                .ToList();
            //TaskNames = File.ReadAllLines("tasks.txt").ToList();
        }
    }
}
