namespace DataAccess.Repository.RepositoryFile
{
    public sealed class BinaryRepositorySettings : FileRepositorySettings
    {
        public BinaryRepositorySettings(string filePath, FileRepositoryMode fileRepositoryMode)
            : base(filePath, fileRepositoryMode)
        {
        }
    }
}