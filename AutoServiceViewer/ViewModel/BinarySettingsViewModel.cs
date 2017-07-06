using AutoServiceViewer.Configurator;
using Microsoft.Win32;
using MVVM;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class BinarySettingsViewModel : ViewModelBase
    {
        private readonly BinaryRepositoryConfigurator _configurator;

        public BinarySettingsViewModel()
        {
            _configurator = new BinaryRepositoryConfigurator();
        }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());


        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "dat | *.dat"
            };
            if (ofd.ShowDialog() == true)
            {
                _configurator.FileName = ofd.FileName;
                _configurator.UpdateContainer(IocApp.Container);
            }
        }

    }
}
