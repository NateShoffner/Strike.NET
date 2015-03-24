#region

using System;
using System.Runtime.Serialization;

#endregion

namespace StrikeNET
{
    [Serializable]
    public class StrikeException : Exception
    {
        public StrikeException()
        {
        }

        public StrikeException(string message) : base(message)
        {
        }

        public StrikeException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public StrikeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public StrikeException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
        }

        protected StrikeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}