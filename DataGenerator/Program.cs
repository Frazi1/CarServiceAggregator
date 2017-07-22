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
            Random r = new Random();

            Console.WriteLine("Number Customers");
            int countCustomers = int.Parse(Console.ReadLine());


            var repositories = new List<IRepository>
            {
                new XmlRepository(new XmlRepositorySettings(FilePaths["xml"], FileMode.Create)),
                new BinaryRepository(new BinaryRepositorySettings(FilePaths["binary"], FileMode.Create)),
                new DatabaseRepository(
                    new DatabaseRepositorySettings(ConnectionString, DatabaseConnectionAction.Create))
            };

            DataGenerator generator = new DataGenerator( /*true,*/ countCustomers, r);
            foreach (IRepository repo in repositories)
            {
                foreach (Customer item in generator.Customers)
                    repo.AddCustomer(item);
                foreach (Order item in generator.Orders)
                    repo.AddOrder(item);
                foreach (Car car in generator.Cars)
                    repo.AddCar(car);
                repo.SaveChanges();
            }

            CopyFiles();
            Console.ReadLine();
        }

        private static void CopyFiles()
        {
            const string prefixNewPath = @"../../../DataAccess/DataForTest/";
            foreach (var sourcePath in FilePaths)
            {
                string oldPath = sourcePath.Value;
                string newPath = prefixNewPath + sourcePath.Value;
                if (File.Exists(newPath))
                    File.Delete(newPath);
                File.Copy(oldPath, newPath);
            }
            Console.WriteLine($"Copied to {prefixNewPath}");
        }

        private static void Initialize()
        {
            FilePaths.Add("xml", "AutoService.xml");
            FilePaths.Add("binary", "AutoService.dat");
        }
    }
}