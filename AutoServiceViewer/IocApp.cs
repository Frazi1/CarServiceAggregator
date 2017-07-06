using AutoServiceViewer.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    public class IocApp
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container {
            get {
                if (_container == null) _container = new UnityContainer();
                return _container;
            }
        }

        protected IocApp()
        { }
    }
}
