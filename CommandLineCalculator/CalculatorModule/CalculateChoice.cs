
namespace CommandLineCalculator.CalculatorModule
{
    public class CalculateChoice
    {
        private CalculateRequest _calculateRequest;
        private CalculateResponse _calculateResponse;
        public CalculateChoice(CalculateRequest calculateRequest)
        {
            _calculateRequest = calculateRequest;
        }

        public CalculateResponse ChoiceOperation()
        {
            var operators = new Operators();
            if (!operators.Contains(_calculateRequest.OperatorType))
                throw (new InvalidOperatorsException("Invalid Operators"));

            switch(_calculateRequest.OperatorType)
            {
                case "/":
                    Divide divide = new Divide();
                    _calculateResponse = divide.Calculate(_calculateRequest);
                    break;
                case "*":
                    Multiple multiple = new Multiple();
                    _calculateResponse = multiple.Calculate(_calculateRequest);
                    break;
                case "+":
                    Add add = new Add();
                    _calculateResponse = add.Calculate(_calculateRequest);
                    break;
                case "-":
                    Substract substract = new Substract();
                    _calculateResponse = substract.Calculate(_calculateRequest);
                    break;
                default:
                    throw (new InvalidOperatorsException("Undefined Operators"));
            }
            return _calculateResponse;
        }
    }
}
