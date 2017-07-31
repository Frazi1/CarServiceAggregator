namespace DataAccess.Repository.RepositoryFile
{
    public class FileRepositorySettings : RepositorySettings
    {
        public FileRepositorySettings(string filePath, FileRepositoryMode fileRepositoryMode)
        {
            FilePath = filePath;
            FileRepositoryMode = fileRepositoryMode;
        }

        public string FilePath { get; }
        public FileRepositoryMode FileRepositoryMode { get; }
    }
}