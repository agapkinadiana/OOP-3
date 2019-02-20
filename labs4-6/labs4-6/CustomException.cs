using System;

namespace labs4_6
{
    abstract class CustomException : Exception
    {
        public string ErrorClass { get; set; }

        public CustomException(string message, string ErrorClass)
            : base(message)
        {
            this.ErrorClass = ErrorClass;
        }
    }
}
