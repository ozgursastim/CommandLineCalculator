namespace CommandLineCalculator.CalculatorModule
{
    /*
     * The class where the values returned from the calculations are kept.
     */
    public class CalculateResponse
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
        public decimal CalculatedValue { get; set; }
        public CalculateResponse()
        {
            Status = true;
            ErrorMessage = "";
            CalculatedValue = 0;
        }
    }
}
