using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class StackFibonacciStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibonacci = new Stack<long>();

            fibonacci.Push(0);
            fibonacci.Push(1);

            for (int i = 1; i < n; i++)
            {
                long first = fibonacci.Pop();
                long second = fibonacci.Peek();

                fibonacci.Push(first);
                fibonacci.Push(first + second);
            }

            Console.WriteLine(fibonacci.Pop());
        }
    }
}
