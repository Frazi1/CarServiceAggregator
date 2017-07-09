using System;
using System.Collections.Generic;
using System.IO;
using DataAccess.Model;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using DataGeneratorLib;

namespace DataGeneratorConsole
{
    internal class Program
    {
        private const string ConnectionString =
            "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>();

        private static void Main(string[] args)
        {
            Initialize();
            DataGenerator generator;
            Random r = new Random();

            Console.WriteLine("Number Customers");
            var countCustomers = int.Parse(Console.ReadLine());
            Console.WriteLine("Number orders");
            var countOrders = int.Parse(Console.ReadLine());

            

            var repositories = new List<IRepository>
            {
                new XmlRepository(new XmlRepositorySettings(FilePaths["xml"], FileMode.Create)),
                new BinaryRepository(new BinaryRepositorySettings(FilePaths["binary"], FileMode.Create)),
                new DatabaseRepository(
                    new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create))
            };

            foreach (IRepository repo in repositories)
            {
                generator = new DataGenerator(true);
                generator.GenerateCustomer(countCustomers, r);
                generator.GenerateOrder(countOrders, r);
                foreach (Customer item in generator.Customers)
                    repo.AddCustomer(item);
                foreach (Order item in generator.Orders)
                    repo.AddOrder(item);
                repo.SaveChanges();
            }

            CopyFiles();
        }

        private static void CopyFiles()
        {
            const string prefixNewPath = @"../../../DataForTest/";
            foreach (var sourcePath in FilePaths)
            {
                var oldPath = sourcePath.Value;
                var newPath = prefixNewPath + sourcePath.Value;
                if(File.Exists(newPath))
                    File.Delete(newPath);
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