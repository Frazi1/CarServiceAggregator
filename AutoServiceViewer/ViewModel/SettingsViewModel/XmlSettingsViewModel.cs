using System.Windows.Input;
using AutoServiceViewer.RepositoryRegistrator;
using Microsoft.Win32;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class XmlSettingsViewModel : ViewModelBase
    {
        private readonly XmlRepositoryRegistrator _registrator;

        public XmlSettingsViewModel()
        {
            _registrator = new XmlRepositoryRegistrator();
        }

        public ICommand OpenFileCommand {
            get { return new RelayCommand(o => OpenFile()); }
        }

        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Xml файлы (*.xml, *.xmlns)|*.xml;*.xmlns|Все файлы (*.*)|*.*"
            };
            if (ofd.ShowDialog() != true) return;
            _registrator.FileName = ofd.FileName;
            _registrator.Register(IocApp.Container);
        }
    }
}