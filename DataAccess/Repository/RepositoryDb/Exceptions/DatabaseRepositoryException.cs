using System;
using System.Runtime.Serialization;

namespace DataAccess.Repository.RepositoryDb
{
    [Serializable]
    public class DatabaseRepositoryException : Exception
    {
        public DatabaseRepositoryException()
        {
        }

        public DatabaseRepositoryException(string message) : base(message)
        {
        }

        public DatabaseRepositoryException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DatabaseRepositoryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}