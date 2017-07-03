using DataAccess;
using DataAccess.Model;
using DataAccess.RepositoryFile;
using DataAccess.RepositoryFile.RepositoryXML;
using System;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer()
            {
                ID = 1,
                FirstName = "Valera",
                Surname = "Petuhov",
                BirthYear = 1996,
                Patronymic = "Velerovich",
                PhoneNumber = "333333333333"
            };

            var customer2 = new Customer()
            {
                ID = 2,
                FirstName = "Evgeny",
                Surname = "Petrov"
            };
            IRepository repo;
            const string connectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";
            //const string connectionString = "server=localhost;port=3306;database=auto_service_db;uid=root;password=Ghuvml134";
            //AutoServiceDb db = new AutoServiceDb(connectionString);
            //db.Customers.Add(customer1);
            //db.SaveChanges();

            // repo = new DatabaseRepository(
            //    new DatabaseRepositorySettings(connectionString));
            //repo.AddCustomer(customer2);
            //repo.SaveChanges();

            repo = new XMLRepository(new XMLRepositorySettings("AutoService.xml", System.IO.FileMode.CreateNew));
            repo.AddCustomer(customer1);
            repo.AddCustomer(customer2);
            repo.SaveChanges();
        

            Console.ReadKey();
        }
    }
}
