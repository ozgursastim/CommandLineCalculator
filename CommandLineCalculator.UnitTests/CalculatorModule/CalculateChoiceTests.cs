using NUnit.Framework;
using CommandLineCalculator.CalculatorModule;

namespace CommandLineCalculator.UnitTests
{
    [TestFixture]
    public class CalculateChoiceTests
    {
        private CalculateRequest _calculateRequest;

        [SetUp]
        public void SetUp()
        {
            _calculateRequest = new CalculateRequest();
        }


        [Test]
        [TestCase(2, 1, "/", 2)]
        public void ChoiceOperation_WhenCalledWithSignOfDivide_ReturnTheDivideOperationResult(decimal value1, decimal value2, string operationType, decimal expectedValue)
        {

            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;
            _calculateRequest.OperatorType = operationType;
            var calculateChoice = new CalculateChoice(_calculateRequest);

            var result = calculateChoice.ChoiceOperation();

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }

        [Test]
        [TestCase(2, 1, "*", 2)]
        public void ChoiceOperation_WhenCalledWithSignOfMultiple_ReturnTheMultipleOperationResult(decimal value1, decimal value2, string operationType, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;
            _calculateRequest.OperatorType = operationType;
            var calculateChoice = new CalculateChoice(_calculateRequest);

            var result = calculateChoice.ChoiceOperation();

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }

        [Test]
        [TestCase(2, 1, "+", 3)]
        public void ChoiceOperation_WhenCalledWithSignOfSum_ReturnTheSumOperationResult(decimal value1, decimal value2, string operationType, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;
            _calculateRequest.OperatorType = operationType;
            var calculateChoice = new CalculateChoice(_calculateRequest);

            var result = calculateChoice.ChoiceOperation();

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }

        [Test]
        [TestCase(2, 1, "-", 1)]
        public void ChoiceOperation_WhenCalledWithSignOfSubstract_ReturnTheSubstractOperationResult(decimal value1, decimal value2, string operationType, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;
            _calculateRequest.OperatorType = operationType;
            var calculateChoice = new CalculateChoice(_calculateRequest);

            var result = calculateChoice.ChoiceOperation();

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }
    }
}
