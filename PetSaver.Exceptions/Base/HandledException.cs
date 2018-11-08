using System;

namespace PetSaver.Exceptions
{
    public class HandledException : Exception
    {
        public HandledException()
        {
        }

        public HandledException(string message)
            : base(message)
        {
        }

        public HandledException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
