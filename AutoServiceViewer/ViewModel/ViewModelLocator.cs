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

        public MainViewModel MainViewModel {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public XmlSettingsViewModel XmlSettingsViewModel {
            get { return ServiceLocator.Current.GetInstance<XmlSettingsViewModel>(); }
        }

        public BinarySettingsViewModel BinarySettingsViewModel {
            get { return ServiceLocator.Current.GetInstance<BinarySettingsViewModel>(); }
        }
    }
}