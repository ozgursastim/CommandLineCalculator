using CommandLineCalculator.CalculatorModule;
using NUnit.Framework;

namespace CommandLineCalculator.UnitTests
{
    [TestFixture]
    public class MultipleTests
    {
        private Multiple _multiple;
        private CalculateRequest _calculateRequest;

        [SetUp]
        public void SetUp()
        {
            _multiple = new Multiple();
            _calculateRequest = new CalculateRequest();
        }

        [Test]
        [TestCase(2, 1, 2)]
        public void Calculate_WhenCalled_ReturnTheMultipleOfArguments(decimal value1, decimal value2, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;

            var result = _multiple.Calculate(_calculateRequest);

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }
    }
}
