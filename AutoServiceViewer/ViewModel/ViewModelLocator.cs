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
            get => ServiceLocator.Current.GetInstance<MainViewModel>();
        }

        public XMLSettingsViewModel XMLSettingsViewModel {
            get => ServiceLocator.Current.GetInstance<XMLSettingsViewModel>();
        }

        public BinarySettingsViewModel BinarySettingsViewModel {
            get => ServiceLocator.Current.GetInstance<BinarySettingsViewModel>();
        }

        public DatabaseSettingsViewModel DatabaseSettingsViewModel {
            get => ServiceLocator.Current.GetInstance<DatabaseSettingsViewModel>();
        }
    }
}
