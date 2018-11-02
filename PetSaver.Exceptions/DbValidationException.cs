using System;

namespace PetSaver.Exceptions
{
    public class DbValidationException : Exception
    {
        public DbValidationException()
        {
        }

        public DbValidationException(string message)
            : base(message)
        {
        }

        public DbValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
