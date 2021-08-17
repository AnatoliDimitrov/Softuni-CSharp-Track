using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OddLines
{
    class OddLinesStart
    {
        static void Main()
        {
            using StreamReader reader = new StreamReader(Path.Combine("..", "..","..","Input.txt"));

            using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Output.txt"));

            int counter = 0;

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }
                else if (counter % 2 != 0)
                {
                    writer.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
