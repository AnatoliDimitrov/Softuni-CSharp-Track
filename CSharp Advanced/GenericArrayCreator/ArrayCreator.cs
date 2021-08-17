using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int count, T item)
        {
            T[] arr = new T[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = item;
            }

            return arr;
        }
    }
}
