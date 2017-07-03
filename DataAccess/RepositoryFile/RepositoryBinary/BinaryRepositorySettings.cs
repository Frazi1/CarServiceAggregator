using System.IO;

namespace DataAccess.RepositoryFile.RepositoryBinary
{
    public sealed class BinaryRepositorySettings : FileRepositorySettings
    {
        public BinaryRepositorySettings(string filePath, FileMode fileMode) 
            : base(filePath, fileMode)
        {
        }
    }
}