using System;

namespace labs4_6
{
    class PortException : CustomException
    {
        public int CountException { get; set; }
        public int ExpectedCount { get; set; }

        public PortException(string message, int CountException, int ExpectedCount)
            : base(message, "Port")
        {
            this.CountException = CountException;
            this.ExpectedCount = ExpectedCount;
        }
    }
}
