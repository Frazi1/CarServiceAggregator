using System.Windows.Input;
using AutoServiceViewer.UnityExtensions;
using Microsoft.Win32;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class XmlSettingsViewModel : ViewModelBase
    {
        private string _selectedFilePath;
        private UnityXmlRepositoryExtension _xmlExtension;


        public string SelectedFilePath {
            get { return _selectedFilePath; }
            set {
                _selectedFilePath = value;
                NotifyPropertyChanged();
            }
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
            SelectedFilePath = ofd.FileName;
            Register();
        }

        private void Register()
        {
            _xmlExtension = new UnityXmlRepositoryExtension(SelectedFilePath);
            IocApp.Container.AddExtension(_xmlExtension);
        }
    }
}