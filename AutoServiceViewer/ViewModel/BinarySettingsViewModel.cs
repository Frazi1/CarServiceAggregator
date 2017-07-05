using DataAccess;
using DataAccess.RepositoryFile.RepositoryBinary;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using MVVM;
using System.IO;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class BinarySettingsViewModel : ViewModelBase, IRepositorySettingCreator<BinaryRepositorySettings>
    {
        public string FileName { get; set; }
        public FileMode FileMode { get; set; }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());

        public BinaryRepositorySettings Create()
        {
            return new BinaryRepositorySettings(FileName, FileMode);
        }

        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "dat | *.dat"
            };
            if (ofd.ShowDialog() == true)
            {
                FileName = ofd.FileName;
                FileMode = FileMode.Open;
                UpdateContainer();
            }
        }
        private void UpdateContainer()
        {
            var settings = Create();
            IocApp.Container.RegisterType<IRepository, BinaryRepository>();
            IocApp.Container.RegisterInstance(settings);
        }
    }
}
