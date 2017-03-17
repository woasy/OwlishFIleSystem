using System;
using System.Runtime.Serialization;

namespace OwlishFileSystem.Generic
{
    [Serializable]
    internal class InvalidTypeOfOwlishFileSystemException : Exception
    {
        public InvalidTypeOfOwlishFileSystemException()
        {
        }

        public InvalidTypeOfOwlishFileSystemException(string message) : base(message)
        {
        }

        public InvalidTypeOfOwlishFileSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTypeOfOwlishFileSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}