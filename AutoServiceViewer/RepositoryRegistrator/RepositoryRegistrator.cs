using DataAccess.Repository;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    /// <summary>
    /// Базовый класс для регистратора репозиториев <typeparam name="T"></typeparam>
    /// </summary>
    /// <typeparam name="T">объект <c>IRepository</c></typeparam>
    public abstract class RepositoryRegistrator<T>
        where T : IRepository
    {
        /// <summary>
        /// Регистрирует объект <c>RepositorySettings</c> в указанном <param name="container"></param>
        /// </summary>
        /// <param name="container">контейнер</param>
        protected abstract void RegisterSettings(IUnityContainer container);

        /// <summary>
        /// Регистрирует <typeparamref name="T"/> в указанном <param name="container"></param>
        /// </summary>
        /// <param name="container">контейнер</param>
        protected abstract void RegisterRepository(IUnityContainer container);

        /// <summary>
        /// Выполняет все действия, необходимые для регистрации репозитория <typeparamref name="T"/>
        /// </summary>
        /// <param name="container"></param>
        public void Register(IUnityContainer container)
        {
            if (!container.IsRegistered<T>())
                RegisterRepository(container);
            RegisterSettings(container);
        }
    }
}