using System.Collections.Generic;
using DataAccess.Model;
using ExceptionHandling;

namespace DataAccess.Repository
{
    public interface IRepository : IErrorReporter
    {
        /// <summary>
        /// Запрашивает перечисление Customer из репозитория.
        /// </summary>
        /// <returns>Всех Customers, которые содержатся в репозитории.</returns>
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Запрашивает перечисление Order из репозитория.
        /// </summary>
        /// <returns>Все Orders, которые содержатся в репозитории.</returns>
        IEnumerable<Order> GetOrders();

        /// <summary>
        /// Запрашивает перечисление Car из репозитория.
        /// </summary>
        /// <returns>Все Cars, которые содержатся в репозитории.</returns>
        IEnumerable<Car> GetCars();

        /// <summary>
        /// Добавляет Order в репозиторий (не сохраняя изменения).
        /// </summary>
        /// <param name="order"></param>
        void AddOrder(Order order);

        /// <summary>
        /// Добавляет Customer в репозиторий (не сохраняя изменения).
        /// </summary>
        /// <param name="customer"></param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// Добавляет Car в репозиторий (не сохраняя изменения).
        /// </summary>
        /// <param name="car"></param>
        void AddCar(Car car);

        //Order GetOrder(int id);
        //Customer GetCustomer(int id);

        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        void SaveChanges();
    }
}