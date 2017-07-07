using DataAccess.Repository;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public abstract class RepositoryRegistrator<T>
        where T : IRepository
    {
        protected abstract void RegisterSettings(IUnityContainer container);

        protected virtual void RegisterRepository(IUnityContainer container)
        {
            var name = typeof(T).Name;
            container.RegisterType<IRepository, T>(name);
        }

        public void Register(IUnityContainer container)
        {
            RegisterRepository(container);
            RegisterSettings(container);
        }
    }
}