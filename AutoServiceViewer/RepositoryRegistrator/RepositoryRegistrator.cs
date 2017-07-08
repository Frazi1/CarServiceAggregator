using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public abstract class RepositoryRegistrator<T>
    {
        protected abstract void RegisterSettings(IUnityContainer container);

        protected abstract void RegisterRepository(IUnityContainer container);

        public void Register(IUnityContainer container)
        {
            if (!container.IsRegistered<T>())
                RegisterRepository(container);
            RegisterSettings(container);
        }
    }
}