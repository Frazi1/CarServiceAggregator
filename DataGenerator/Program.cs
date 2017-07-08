using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using DataGeneratorLib;

namespace DataGeneratorConsole
{
    class Program
    {
        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>();
        private const string ConnectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";

        static void Main(string[] args)
        {
            Initialize();
            DataGenerator generator = new DataGenerator(true);
            Random r = new Random();

            Console.WriteLine("Number Customers");
            int countCustomers = int.Parse(Console.ReadLine());
            Console.WriteLine("Number orders");
            int countOrders = int.Parse(Console.ReadLine());

            generator.GenerateCustomer(countCustomers, r);
            generator.GenerateOrder(countOrders, r);

            List<IRepository> repositories = new List<IRepository>
            {
                new XmlRepository(new XmlRepositorySettings(FilePaths["xml"], FileMode.Create)),
                new BinaryRepository(new BinaryRepositorySettings(FilePaths["binary"], FileMode.Create)),
                new DatabaseRepository(
                    new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create))
            };

            foreach (IRepository repo in repositories)
            {
                foreach (var item in generator.Customers)
                {
                    repo.AddCustomer(item);
                }
                foreach (var item in generator.Orders)
                {
                    repo.AddOrder(item);
                }
                repo.SaveChanges();
            }

            CopyFiles();
        }

        private static void CopyFiles()
        {
            const string prefixNewPath = @"../../../DataForTest/";
            foreach (var sourcePath in FilePaths)
            {
                string oldPath = sourcePath.Value;
                string newPath = prefixNewPath + sourcePath.Value;
                File.Copy(oldPath, newPath);
            }
        }

        private static void Initialize()
        {
            FilePaths.Add("xml", "AutoService.xml");
            FilePaths.Add("binary", "AutoService.dat");
        }
    }
}
