using System;
using System.Text;

namespace DigitsLettersAndOther
{
    class DigitsLettersAndOtherStart
    {
        static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder other = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsDigit(c))
                {
                    digits.Append(c);
                }
                else if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
                else
                {
                    other.Append(c);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
