﻿using DataAccess;
using DataAccess.RepositoryFile.RepositoryXML;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using MVVM;
using System.IO;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class XMLSettingsViewModel : ViewModelBase, IRepositorySettingCreator<XMLRepositorySettings>
    {
        public string FileName { get; set; }
        public FileMode FileMode { get; set; }

        public ICommand OpenFileCommand => new RelayCommand(o => OpenFile());

        public XMLRepositorySettings Create()
        {
            return new XMLRepositorySettings(FileName, FileMode);
        }

        private void OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "xml | *.xml"
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
            IocApp.Container.RegisterType<IRepository, XMLRepository>(/*"xml"*/);
            IocApp.Container.RegisterInstance(settings);
        }
    }
}