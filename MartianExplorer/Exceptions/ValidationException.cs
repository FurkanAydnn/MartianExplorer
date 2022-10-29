using System;

namespace MartianExplorer.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() { }
        public ValidationException(string message) : base($"Invalid characters detected while validation. {message}") { }
    }
}
