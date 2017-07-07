using AutoServiceViewer.Configurator;
using Microsoft.Win32;
using MVVM;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class XmlSettingsViewModel : ViewModelBase
    {
        private readonly XmlRepositoryConfigurator _configurator;

        public XmlSettingsViewModel()
        {
            _configurator = new XmlRepositoryConfigurator();
        }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());
        
        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "xml | *.xml"
            };
            if (ofd.ShowDialog() != true) return;
            _configurator.FileName = ofd.FileName;
            _configurator.UpdateContainer(IocApp.Container);
        }
    }
}
