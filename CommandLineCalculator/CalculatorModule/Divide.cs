using System;

namespace CommandLineCalculator.CalculatorModule
{
    /*
     * Dividing process class
     * Takes CalculateRequest Class as a parameter
     * Response CalculateResponse Class
     */
    public class Divide : CalculateBase
    {
        private readonly CalculateResponse _calculateResponse = new CalculateResponse();
        public override CalculateResponse Calculate(CalculateRequest calculateRequest)
        {
            try
            {
                _calculateResponse.CalculatedValue = calculateRequest.FirstValue / calculateRequest.SecondValue;
                _calculateResponse.Status = true;
            }
            catch (Exception ex)
            {
                _calculateResponse.Status = false;
                _calculateResponse.ErrorMessage = ex.Message;
                throw (new DivideByZeroException());
            }
            return _calculateResponse;
        }
    }
}
