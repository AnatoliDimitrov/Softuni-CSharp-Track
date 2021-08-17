using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplyBigNumber
{
    class MultiplyBigNumberStart
    {
        static void Main()
        {
            string number = Console.ReadLine();
            int multiplayer = int.Parse(Console.ReadLine());

            if (multiplayer == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int reminder = 0;

            List<char> result = new List<char>();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int num = int.Parse(number[i].ToString());
                int multiplied = num * multiplayer + reminder;

                result.Add(Convert.ToChar((multiplied % 10).ToString()));
                reminder = multiplied / 10;
            }

            if (reminder != 0)
            {
                result.Add(Convert.ToChar(reminder.ToString()));
            }
            result.Reverse();

            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[0] == '0')
                {
                    result.RemoveAt(0);
                    i--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
