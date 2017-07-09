using System.Windows.Input;
using AutoServiceViewer.RepositoryRegistrator;
using Microsoft.Win32;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class BinarySettingsViewModel : ViewModelBase
    {
        private readonly BinaryRepositoryRegistrator _registrator;

        public BinarySettingsViewModel()
        {
            _registrator = new BinaryRepositoryRegistrator();
        }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());


        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Бинарный файл (*.dat)|*.dat|Все файлы (*.*)|*.*"
            };
            if (ofd.ShowDialog() != true) return;
            _registrator.FileName = ofd.FileName;
            _registrator.Register(IocApp.Container);
        }
    }
}