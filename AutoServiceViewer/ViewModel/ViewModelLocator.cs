using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(IocApp.Container));
        }

        public MainViewModel MainViewModel
            => ServiceLocator.Current.GetInstance<MainViewModel>();

        public XmlSettingsViewModel XmlSettingsViewModel
            => ServiceLocator.Current.GetInstance<XmlSettingsViewModel>();

        public BinarySettingsViewModel BinarySettingsViewModel
            => ServiceLocator.Current.GetInstance<BinarySettingsViewModel>();
    }
}