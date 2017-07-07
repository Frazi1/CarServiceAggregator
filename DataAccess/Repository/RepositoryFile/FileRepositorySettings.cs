using System.IO;

namespace DataAccess.Repository.RepositoryFile
{
    public class FileRepositorySettings : RepositorySettings
    {
        public FileRepositorySettings(string filePath, FileMode fileMode)
        {
            FilePath = filePath;
            FileMode = fileMode;
        }

        public string FilePath { get; }
        public FileMode FileMode { get; }
    }
}