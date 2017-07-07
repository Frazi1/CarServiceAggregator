using System.IO;

namespace DataAccess.RepositoryFile.RepositoryXML
{
    public sealed class XmlRepositorySettings : FileRepositorySettings
    {
        public XmlRepositorySettings(string filePath, FileMode fileMode) 
            : base(filePath, fileMode)
        {
        }
    }
}