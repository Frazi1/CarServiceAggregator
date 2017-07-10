using System;
using System.Runtime.Serialization;

namespace DataAccess.Repository.RepositoryDb
{

    [Serializable]
    public class DatabaseRepositoryException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

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