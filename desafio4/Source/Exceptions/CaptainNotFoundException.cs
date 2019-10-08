using System;
using System.Runtime.Serialization;

namespace Codenation.Challenge.Exceptions
{
    
    [Serializable]
    public class CaptainNotFoundException: Exception
    {
        public CaptainNotFoundException()
        {
        }

        public CaptainNotFoundException(string message)
            : base(message)
        {
        }

        public CaptainNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CaptainNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }    
}