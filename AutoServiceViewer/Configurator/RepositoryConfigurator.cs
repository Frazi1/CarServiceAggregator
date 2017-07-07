using DataAccess;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.Configurator
{
    public abstract class RepositoryConfigurator<T, I>
           where T : IRepository
           where I : RepositorySettings
    {
        protected abstract I GetSettings();

        public virtual void UpdateContainer(IUnityContainer container)
        {
            var settings = GetSettings();
            string name = typeof(T).Name;
            container.RegisterType<IRepository, T>(name);
            container.RegisterInstance(settings);
        }
    }
}
