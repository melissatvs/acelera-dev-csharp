using System;
using System.Runtime.Serialization;

namespace Codenation.Challenge.Exceptions
{
    
    [Serializable]
    public class TeamNotFoundException: Exception
    {
        public TeamNotFoundException()
        {
        }

        public TeamNotFoundException(string message)
            : base(message)
        {
        }

        public TeamNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TeamNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }    
}