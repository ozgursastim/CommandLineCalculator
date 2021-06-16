using System;
using System.Collections;
using System.Collections.Generic;

namespace CommandLineCalculator.CalculatorModule
{
    /*
     * The class in which operators are stored in order of operation.
     */
    public class Operators : IList<string>
    {
        private readonly List<string> _operatorList = new List<string>(new string[] { });

        public int Count => _operatorList.Count;

        public bool IsReadOnly => true;

        public string this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Operators()
        {
            _operatorList.Add("/");
            _operatorList.Add("*");
            _operatorList.Add("+");
            _operatorList.Add("-");
        }
        public int IndexOf(string item)
        {
            return _operatorList.IndexOf(item);
        }

        public void Insert(int index, string item)
        {
            _operatorList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _operatorList.RemoveAt(index);
        }

        public void Add(string item)
        {
            _operatorList.Add(item);
        }

        public void Clear()
        {
            _operatorList.Clear();
        }

        public bool Contains(string item)
        {
            return _operatorList.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _operatorList.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            return _operatorList.Remove(item);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _operatorList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
