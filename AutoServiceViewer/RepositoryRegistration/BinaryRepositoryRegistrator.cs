using AutoServiceViewer.UnityExtensions;
using Microsoft.Win32;

namespace AutoServiceViewer.RepositoryRegistration
{
    public class BinaryRepositoryRegistrator : RepositoryRegistrator
    {
        public override bool Register()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Бинарный файл (*.dat)|*.dat|Все файлы (*.*)|*.*"
            };
            if (ofd.ShowDialog() != true) return false;
            UnityBinaryRepositoryExtension binaryExtension = new UnityBinaryRepositoryExtension(ofd.FileName);
            IocApp.Container.AddExtension(binaryExtension);
            return true;
        }
    }
}