using AutoServiceViewer.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    public static class IocApp
    {
        private static IUnityContainer _container;
        public static IUnityContainer Container => _container;

        public static void Initialize()
        {
            if (_container != null) return;
            _container = new UnityContainer();

            //_container.RegisterType<MainViewModel>();
            //_container.RegisterType<XMLSettingsViewModel>();
            //_container.RegisterType<BinarySettingsViewModel>();
            //ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_container));
        }
    }
}
