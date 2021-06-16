using System;

namespace CommandLineCalculator.CalculatorModule
{
    /*
     * User Defined Exception Error Class
     */
    public class InvalidOperatorsException : Exception
    {
        public InvalidOperatorsException(string message) : base(message) { }
    }
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
