using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceViewer.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel {
            get => IocApp.Container.Resolve<MainViewModel>();
        }

        public XMLSettingsViewModel XMLSettingsViewModel {
            get => IocApp.Container.Resolve<XMLSettingsViewModel>();
        }
    }
}
