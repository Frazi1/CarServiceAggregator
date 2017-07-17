using System.Windows.Input;
using AutoServiceViewer.UnityExtensions;
using Microsoft.Win32;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class BinarySettingsViewModel : ViewModelBase
    {
        private UnityBinaryRepositoryExtension _binaryExtension;
        private string _selectedFilePath;

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
                Filter = "Бинарный файл (*.dat)|*.dat|Все файлы (*.*)|*.*"
            };
            if (ofd.ShowDialog() != true) return;
            SelectedFilePath = ofd.FileName;
            Register();
        }

        private void Register()
        {
            _binaryExtension = new UnityBinaryRepositoryExtension(SelectedFilePath);
            IocApp.Container.AddExtension(_binaryExtension);
        }
    }
}