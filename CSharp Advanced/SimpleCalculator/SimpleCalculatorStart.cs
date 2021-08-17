using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class SimpleCalculatorStart
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ");
            Stack<string> calculator = new Stack<string>(input.Reverse());

            while (calculator.Count > 1)
            {
                int first = int.Parse(calculator.Pop());
                string _operator = calculator.Pop();
                int second = int.Parse(calculator.Pop());

                if (_operator == "+")
                {
                    calculator.Push((first + second).ToString());
                }
                else
                {
                    calculator.Push((first - second).ToString());
                }
            }

            Console.WriteLine(calculator.Pop());
        }
    }
}
