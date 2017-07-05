using System.IO;

namespace DataAccess.RepositoryFile
{
    public class FileRepositorySettings : RepositorySettings
    {
        public string FilePath { get; }
        public FileMode FileMode { get; }

        public FileRepositorySettings(string filePath, FileMode fileMode)
        {
            FilePath = filePath;
            FileMode = fileMode;
        }
    }
}