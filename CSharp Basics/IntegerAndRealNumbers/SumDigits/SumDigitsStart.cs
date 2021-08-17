namespace SumDigits
{
    using System;
    using System.Collections.Generic;

    class SumDigitsStart
    {
        static void Main()
        {
            string number = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum += int.Parse(number[i].ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
