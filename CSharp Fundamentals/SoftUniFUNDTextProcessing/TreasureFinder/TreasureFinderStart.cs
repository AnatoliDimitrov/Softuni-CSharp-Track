using System;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class TreasureFinderStart
    {
        static void Main()
        {
            int[] keySequence = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
 
            string input = "";

            while ((input = Console.ReadLine()) != "find")
            {
                int counter = 0;

                StringBuilder result = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    int c = (int)input[i];
                    result.Append(Convert.ToChar(c - keySequence[counter]));
                    counter++;
                    if (counter == keySequence.Length)
                    {
                        counter = 0;
                    }
                }

                int materialStart = result.ToString().IndexOf('&');
                int materialEnd = result.ToString().IndexOf('&', materialStart + 1);

                string material = Find(result, materialStart, materialEnd);

                int locationStart = result.ToString().IndexOf('<');
                int locationEnd = result.ToString().IndexOf('>');

                string location = Find(result, locationStart, locationEnd);

                Console.WriteLine($"Found {material} at {location}");
            }
        }

        static string Find(StringBuilder location, int start, int end)
        {
            string word = location.ToString().Substring(start + 1, end - start - 1);
            return word;
        }
    }
}
