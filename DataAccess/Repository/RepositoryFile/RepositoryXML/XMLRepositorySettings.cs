using System.IO;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class XmlRepositorySettings : FileRepositorySettings
    {
        public XmlRepositorySettings(string filePath, FileMode fileMode)
            : base(filePath, fileMode)
        {
        }
    }
}