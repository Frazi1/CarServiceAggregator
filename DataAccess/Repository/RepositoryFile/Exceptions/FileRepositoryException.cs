using System;
using System.Runtime.Serialization;

namespace DataAccess.Repository.RepositoryFile
{
    [Serializable]
    public class FileRepositoryException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

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