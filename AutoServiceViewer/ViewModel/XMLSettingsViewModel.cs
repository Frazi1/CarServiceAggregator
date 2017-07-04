using DataAccess.RepositoryFile.RepositoryXML;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using MVVM;
using System.IO;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class XMLSettingsViewModel : ViewModelBase
    {
        public string FileName { get; set; }
        public FileMode FileMode { get; set; }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());

        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                //Filter = "*.xml | *.dat"
            };
            if (ofd.ShowDialog() == true)
            {
                FileName = ofd.FileName;
                FileMode = FileMode.Open;
            }
            UpdateContainer();
        }

        private void UpdateContainer()
        {
            var settings = new XMLRepositorySettings(FileName, FileMode);
            IocApp.XMLContainer.RegisterInstance(settings);
        }
    }
}
