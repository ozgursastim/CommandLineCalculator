using NUnit.Framework;
using System;
using CommandLineCalculator.CalculatorModule;

namespace CommandLineCalculator.UnitTests
{
    [TestFixture]
    public class DivideTests
    {
        private Divide _divide;
        private CalculateRequest _calculateRequest;

        [SetUp]
        public void SetUp()
        {
            _divide = new Divide();
            _calculateRequest = new CalculateRequest();
        }
        [Test]
        public void Calculate_InvalidError_ThrowDivideByZeroException()
        {
            _calculateRequest.FirstValue = 2;
            _calculateRequest.SecondValue = 0;

            Assert.That(() => _divide.Calculate(_calculateRequest), Throws.Exception.TypeOf<DivideByZeroException>());
        }

        [Test]
        [TestCase(2, 1, 2)]
        public void Calculate_WhenCalled_ReturnTheDivideOfArguments(decimal value1, decimal value2, decimal expectedValue)
        {
            _calculateRequest.FirstValue = value1;
            _calculateRequest.SecondValue = value2;

            var result = _divide.Calculate(_calculateRequest);

            Assert.That(result.CalculatedValue, Is.EqualTo(expectedValue));

        }
    }
}
