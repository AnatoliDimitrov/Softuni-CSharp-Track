using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    class EqualityScale<TElement> where TElement : IComparable
    {
        private TElement first;
        private TElement second;
        public EqualityScale(TElement firstElement, TElement secondElement)
        {
            first = firstElement;
            second = secondElement;
        }

        public TElement AreEqual()
        {
            if (first.CompareTo(second) == 1)
            {
                return first;
            }
            else if (first.CompareTo(second) == -1)
            {
                return second;
            }
            else
            {
                return default;
            }
        }
    }
}
