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
        static void Main(string[] args)
        {
            DataGenerator generator = new DataGenerator(true);
            Random r = new Random();


            Console.WriteLine("Number Customers");
            int countCustomers = int.Parse(Console.ReadLine());
            Console.WriteLine("Number orders");
            int countOrders = int.Parse(Console.ReadLine());

            generator.GenerateCustomer(countCustomers, r);
            generator.GenerateOrder(countOrders, r);

            const string connectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";
            IRepository repo;
            //repo = new XmlRepository(new XmlRepositorySettings("AutoService3.xml", FileMode.Create));
            //repo = new BinaryRepository(new DataAccess.RepositoryFile.FileRepositorySettings("AutoService.dat", FileMode.Create));
            repo = new DatabaseRepository(new DatabaseRepositorySettings(connectionString, DatabaseConnectionAction.Create));

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

    }
}
