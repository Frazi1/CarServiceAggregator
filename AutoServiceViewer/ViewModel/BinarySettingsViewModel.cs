using Microsoft.Win32;
using MVVM;
using System.Windows.Input;
using AutoServiceViewer.RepositoryRegistrator;

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
            var ofd = new OpenFileDialog
            {
                Filter = "dat | *.dat"
            };
            if (ofd.ShowDialog() != true) return;
            _registrator.FileName = ofd.FileName;
            _registrator.Register(IocApp.Container);
        }

    }
}
