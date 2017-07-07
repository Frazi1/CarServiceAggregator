using System.IO;

namespace DataAccess.Repository.RepositoryFile
{
    public sealed class BinaryRepositorySettings : FileRepositorySettings
    {
        public BinaryRepositorySettings(string filePath, FileMode fileMode)
            : base(filePath, fileMode)
        {
        }
    }
}