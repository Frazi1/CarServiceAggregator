using System;
using System.Runtime.Serialization;

namespace DataAccess.Repository.RepositoryDb
{
    public class DatabaseMissingException : DatabaseRepositoryException
    {
        public DatabaseMissingException() : this("Базы данных не существует")
        {
        }

        public DatabaseMissingException(string message) : base(message)
        {
        }

        public DatabaseMissingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DatabaseMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}