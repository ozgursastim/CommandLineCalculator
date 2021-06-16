using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandLineCalculator.CalculatorModule
{
    /*
     * The class that calculates the values in the string entered from the console.
     * Takes CalculatorRequest Class as a parameter
     */
    public class Calculator
    {
        private readonly Operators _operatorList = new Operators();
        private List<string> _commandLineValueList;
        private CalculatorRequest _calculatorRequest;
        private CalculateResponse _calculateResponse;

        public Calculator(CalculatorRequest calculatorRequest)
        {
            _calculateResponse = new CalculateResponse();
            _calculatorRequest = calculatorRequest;
        }

        /*
         * The module in which the calculation is made
         */
        public CalculateResponse Calculate()
        {
            try
            {
                SplitCommandLineValue();
                ControlCommandLineValue();
                CalculateFromCommandLineValue();
            }
            catch (InvalidOperatorsException ex)
            {
                _calculateResponse.Status = false;
                _calculateResponse.ErrorMessage = ex.Message;
            }
            catch (InvalidInputException ex)
            {
                _calculateResponse.Status = false;
                _calculateResponse.ErrorMessage = ex.Message;
            }
            return _calculateResponse;
        }

        /*
         * The method of the class splits the entered string into parts.
         * It splits the string entered from the console into parts with spaces and transfers it to the list.
         * First of all, the equal sign at the end of the entered string is removed from the string because it is not used.
         */
        private void SplitCommandLineValue()
        {
            _calculatorRequest.ValueToBeCalculated = _calculatorRequest.ValueToBeCalculated.Remove(_calculatorRequest.ValueToBeCalculated.Length - 2, 2);
            _commandLineValueList = _calculatorRequest.ValueToBeCalculated.Split(' ').ToList();
        }

        /*
         * The method of the class controls the entered string.
         * Last of the string has to be number
         * First and even numbers index of the string have to be number
         * Odd numbers index of the string have to be opertor
         */
        private void ControlCommandLineValue()
        {
            decimal numberValue;
            
            if (!Decimal.TryParse(_commandLineValueList[_commandLineValueList.Count - 1], out numberValue))
                throw (new InvalidOperatorsException("Invalid Input Value"));

            for (int i = 0; i < _commandLineValueList.Count; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    if (!Decimal.TryParse(_commandLineValueList[_commandLineValueList.Count - 1], out numberValue))
                        throw (new InvalidOperatorsException("Invalid Input Value"));
                }
                else
                {
                    if (!_operatorList.Contains(_commandLineValueList[i]))
                        throw (new InvalidOperatorsException("Invalid Input Value"));
                }
            }
        }

        /*
         * The method of the class calculates the value
         * Operators kept in the list in order of priority. Each operator is searched in the list in which the string entered from the console is stored.
         * If the operator is in the list, the operator is sent to the CalculateChoice class along with the previous and next numbers.
         * After processing according to the operator type, the returned value is added to the list.
         * The processed numbers and operators are removed from the list.
         * The process is repeated until all the operations in the list are done. In the end, the result of the calculation remains.
         * This value is added to the CalculateResponse class and returned.
         */
        private void CalculateFromCommandLineValue()
        {
            int operatorIndex;

            var calculateRequest = new CalculateRequest();

            try
            {
                foreach (var operatorElement in _operatorList)
                {
                    while(true)
                    {
                        operatorIndex = _commandLineValueList.LastIndexOf(operatorElement);
                        if (operatorIndex == -1)
                            break;

                        calculateRequest.FirstValue = Convert.ToDecimal(_commandLineValueList[operatorIndex - 1]);
                        calculateRequest.SecondValue = Convert.ToDecimal(_commandLineValueList[operatorIndex + 1]);
                        calculateRequest.OperatorType = operatorElement;

                        var calculateChoice = new CalculateChoice(calculateRequest);
                        _calculateResponse = calculateChoice.ChoiceOperation();

                        _commandLineValueList[operatorIndex - 1] = _calculateResponse.CalculatedValue.ToString();
                        _commandLineValueList.RemoveAt(operatorIndex + 1);
                        _commandLineValueList.RemoveAt(operatorIndex);
                    }
                }
                _calculateResponse.CalculatedValue = Convert.ToDecimal(string.Join(" ", _commandLineValueList));
            }
            catch (Exception ex)
            {
                _calculateResponse.Status = false;
                _calculateResponse.ErrorMessage = ex.Message;
                return;
            }
        }
    }
}
