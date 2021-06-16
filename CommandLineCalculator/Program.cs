using System;
using CommandLineCalculator.CalculatorModule;

namespace CommandLineCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorRequest = new CalculatorRequest();
            var calculatorResponse = new CalculateResponse();
            //calculatorRequest.willCalculateValue = "-3 + 100 / 4 =";
            calculatorRequest.ValueToBeCalculated = "9 / 3 + 1 - 2 * 32 / 4 =";
            Calculator calculator = new Calculator(calculatorRequest);
            calculatorResponse = calculator.Calculate();
            Console.WriteLine(calculatorResponse.CalculatedValue.ToString());
            Console.WriteLine(calculatorResponse.ErrorMessage);
            Console.WriteLine(calculatorResponse.Status);
        }
    }
}
