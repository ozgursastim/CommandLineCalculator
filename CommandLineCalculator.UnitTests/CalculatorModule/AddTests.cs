using CommandLineCalculator.CalculatorModule;
using NUnit.Framework;

namespace CommandLineCalculator.UnitTests
{
    [TestFixture]
    public class AddTests
    {
        private Add _add;
        private CalculateRequest _calculateRequest;

        [SetUp]
        public void SetUp()
        {
            _add = new Add();
            _calculateRequest = new CalculateRequest();
        }

        [Test]
        [TestCase(2, 1, 3)]
        public void Calculate_WhenCalled_ReturnTheSumOfArguments(decimal value1, decimal value2, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;

            var result = _add.Calculate(_calculateRequest);

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }
    }
}
