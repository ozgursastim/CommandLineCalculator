namespace CommandLineCalculator.CalculatorModule
{
    /*
     * The class that holds the values to be used in calculations.
     */
    public class CalculateRequest
    {
        public decimal FirstValue { get; set; }
        public decimal SecondValue { get; set; }
        public string OperatorType { get; set; }
    }
}
