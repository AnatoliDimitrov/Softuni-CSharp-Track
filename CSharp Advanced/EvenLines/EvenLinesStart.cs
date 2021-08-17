namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    class EvenLinesStart
    {
        static void Main()
        {
            using StreamReader reader = new StreamReader(Path.Combine("..","..","..","text.txt"));

            int counter = 0;

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }
                else if (counter % 2 == 0)
                {
                    line = Regex.Replace(line, @"[-,\.!?]", "@");

                    string[] words = line
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Array.Reverse(words);

                    Console.WriteLine(string.Join(" ", words));
                }

                counter++;
            }
        }
    }
}
