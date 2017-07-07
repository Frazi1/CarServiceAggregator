using Microsoft.Win32;
using MVVM;
using System.Windows.Input;
using AutoServiceViewer.RepositoryRegistrator;

namespace AutoServiceViewer.ViewModel
{
    public class XmlSettingsViewModel : ViewModelBase
    {
        private readonly XmlRepositoryRegistrator _registrator;

        public XmlSettingsViewModel()
        {
            _registrator = new XmlRepositoryRegistrator();
        }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());
        
        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "xml | *.xml"
            };
            if (ofd.ShowDialog() != true) return;
            _registrator.FileName = ofd.FileName;
            _registrator.Register(IocApp.Container);
        }
    }
}
