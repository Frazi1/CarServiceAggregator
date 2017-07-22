using System;
using System.Runtime.Serialization;

namespace DataAccess.Repository.RepositoryFile
{
    [Serializable]
    public class FileRepositoryException : Exception
    {
        public FileRepositoryException()
        {
        }

        public FileRepositoryException(string message) : base(message)
        {
        }

        public FileRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FileRepositoryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}