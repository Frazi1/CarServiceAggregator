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
    public class DatabaseSettingsViewModel : ViewModelBase, IRepositorySettingCreator<DatabaseRepositorySettings>
    {
        public string FileName { get; set; }
        public FileMode FileMode { get; set; }
        public string ConnectionString { get; set; }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());

        public DatabaseRepositorySettings Create()
        {
            return new DatabaseRepositorySettings(ConnectionString);
        }

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
        private void UpdateContainer()
        {
            var settings = Create();
            IocApp.Container.RegisterType<IRepository, DatabaseRepository>();
            IocApp.Container.RegisterInstance(settings);
        }
    }
}
