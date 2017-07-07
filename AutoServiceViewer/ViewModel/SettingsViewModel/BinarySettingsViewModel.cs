using System.Windows.Input;
using AutoServiceViewer.RepositoryRegistrator;
using Microsoft.Win32;
using MVVM;

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
                Filter = "dat | *.dat"
            };
            if (ofd.ShowDialog() != true) return;
            _registrator.FileName = ofd.FileName;
            _registrator.Register(IocApp.Container);
        }
    }
}