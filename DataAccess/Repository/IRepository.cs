﻿using System.Collections.Generic;
using DataAccess.Model;
using ExceptionHandling;

namespace DataAccess.Repository
{
    public interface IRepository : IErrorReporter
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Order> GetOrders();
        IEnumerable<Car> GetCars();

        void AddOrder(Order order);
        void AddCustomer(Customer customer);
        //Order GetOrder(int id);
        //Customer GetCustomer(int id);

        void SaveChanges();
    }
}