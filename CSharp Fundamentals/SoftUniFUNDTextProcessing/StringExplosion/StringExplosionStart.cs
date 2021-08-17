using System;

namespace StringExplosion
{
    class StringExplosionStart
    {
        static void Main()
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                int stregth = 0;

                if (input[i] == '>')
                {
                    stregth = int.Parse(input[i + 1].ToString());
                    for (int j = i + 1; j < i + 1 + stregth; j++)
                    {
                        if (j == input.Length)
                        {
                            break;
                        }
                        if (input[j] == '>')
                        {
                            stregth += int.Parse(input[j + 1].ToString());
                        }
                        else
                        {
                            input = input.Remove(j, 1);
                            stregth--;
                            j--;
                        }
                        i = j;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}
