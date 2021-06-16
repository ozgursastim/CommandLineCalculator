using CommandLineCalculator.CalculatorModule;
using NUnit.Framework;

namespace CommandLineCalculator.UnitTests
{
    [TestFixture]
    public class SubstractTests
    {
        private Substract _substract;
        private CalculateRequest _calculateRequest;

        [SetUp]
        public void SetUp()
        {
            _substract = new Substract();
            _calculateRequest = new CalculateRequest();
        }

        [Test]
        [TestCase(2, 1, 1)]
        public void Calculate_WhenCalled_ReturnTheSubstractOfArguments(decimal value1, decimal value2, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;

            var result = _substract.Calculate(_calculateRequest);

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }
    }
}
