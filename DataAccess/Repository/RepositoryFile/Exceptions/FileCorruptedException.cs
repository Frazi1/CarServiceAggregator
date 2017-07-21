using System;
using System.Runtime.Serialization;

namespace DataAccess.Repository.RepositoryFile
{
    public class FileCorruptedException : FileRepositoryException
    {
        public FileCorruptedException()
        {
        }

        public FileCorruptedException(string message) : base(message)
        {
        }

        public FileCorruptedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FileCorruptedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}