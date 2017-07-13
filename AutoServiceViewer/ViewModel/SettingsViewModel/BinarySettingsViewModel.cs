using System.Windows.Input;
using AutoServiceViewer.RepositoryRegistrator;
using Microsoft.Win32;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class BinarySettingsViewModel : ViewModelBase
    {
        private string _selectedFilePath;
        private readonly BinaryRepositoryRegistrator _registrator;

        public string SelectedFilePath {
            get { return _selectedFilePath; }
            set {
                _selectedFilePath = value;
                _registrator.FileName = value;
                NotifyPropertyChanged();
            }
        }

        public BinarySettingsViewModel()
        {
            _registrator = new BinaryRepositoryRegistrator();
        }

        public ICommand OpenFileCommand {
            get { return new RelayCommand(o => OpenFile()); }
        }


        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Бинарный файл (*.dat)|*.dat|Все файлы (*.*)|*.*"
            };
            if (ofd.ShowDialog() != true) return;
            SelectedFilePath = ofd.FileName;
            _registrator.Register(IocApp.Container);
        }
    }
}