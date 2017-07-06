using AutoServiceViewer.Configurator;
using DataAccess;
using DataAccess.RepositoryFile.RepositoryXML;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using MVVM;
using System.IO;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class XMLSettingsViewModel : ViewModelBase
    {
        private readonly XMLRepositoryConfigurator _configurator;

        public XMLSettingsViewModel()
        {
            _configurator = new XMLRepositoryConfigurator();
        }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());
        
        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "xml | *.xml"
            };
            if (ofd.ShowDialog() == true)
            {
                _configurator.FileName = ofd.FileName;
                _configurator.UpdateContainer(IocApp.Container);
            }
        }
    }
}
