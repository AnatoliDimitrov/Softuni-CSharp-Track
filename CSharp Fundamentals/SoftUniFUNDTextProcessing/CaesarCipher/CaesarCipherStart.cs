using System;
using System.Text;

namespace CaesarCipher
{
    class CaesarCipherStart
    {
        static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int c = (int)input[i];
                result.Append(Convert.ToChar(c + 3));
            }

            Console.WriteLine(result);
        }
    }
}
