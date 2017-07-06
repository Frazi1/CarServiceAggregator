using AutoServiceViewer.Configurator;
using DataAccess;
using DataAccess.RepositoryDb;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using MVVM;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class DatabaseSettingsViewModel : ViewModelBase
    {
        private readonly DatabaseRepositoryConfigurator _configurator;

        public DatabaseSettingsViewModel()
        {
            _configurator = new DatabaseRepositoryConfigurator();
        }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());

        private void OpenFile()
        {
            //TODO: Написать реализацию для DatabaseSettings

            //var ofd = new OpenFileDialog
            //{
            //    //Filter = "dat | *.dat
            //};
            //if (ofd.ShowDialog() == true)
            //{
            //    FileName = ofd.FileName;
            //    FileMode = FileMode.Open;
            //    UpdateContainer();
            //}
            MessageBox.Show("Not implemented yet");
        }
    }
}
