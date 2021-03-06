
namespace CommandLineCalculator.CalculatorModule
{
    /*
     * Substracting process class
     * Takes CalculateRequest Class as a parameter
     * Response CalculateResponse Class
     */
    public class Substract : CalculateBase
    {
        private readonly CalculateResponse _calculateResponse = new CalculateResponse();
        public override CalculateResponse Calculate(CalculateRequest calculateRequest)
        {
            _calculateResponse.CalculatedValue = calculateRequest.FirstValue - calculateRequest.SecondValue;
            _calculateResponse.Status = true;
            return _calculateResponse;
        }
    }
}
