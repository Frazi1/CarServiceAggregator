using System;
using System.Collections.Generic;
using DataAccess.Model;

namespace DataAccess.Repository.LazyRepository
{
    public class LazyRepository<T> : IRepository
        where T : IRepository
    {
        private readonly Lazy<T> _repositoryLazy;

        public IEnumerable<Customer> Customers => Repository.Customers;
        public IEnumerable<Order> Orders => Repository.Orders;
        public T Repository => _repositoryLazy.Value;

        public LazyRepository(RepositorySettings settings)
        {
            _repositoryLazy = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), settings));
        }

        public void AddOrder(Order order)
        {
            Repository.AddOrder(order);
        }

        public void AddCustomer(Customer customer)
        {
            Repository.AddCustomer(customer);
        }

        public void SaveChanges()
        {
            Repository.SaveChanges();
        }
    }
}