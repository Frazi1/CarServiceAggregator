namespace DataAccess.Repository.RepositoryFile
{
    public sealed class XmlRepositorySettings : FileRepositorySettings
    {
        public XmlRepositorySettings(string filePath, FileRepositoryMode fileRepositoryMode)
            : base(filePath, fileRepositoryMode)
        {
        }
    }
}