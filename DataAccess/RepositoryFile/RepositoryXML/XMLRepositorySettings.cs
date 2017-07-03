using System.IO;

namespace DataAccess.RepositoryFile.RepositoryXML
{
    public sealed class XMLRepositorySettings : FileRepositorySettings
    {
        public XMLRepositorySettings(string filePath, FileMode fileMode) 
            : base(filePath, fileMode)
        {
        }
    }
}