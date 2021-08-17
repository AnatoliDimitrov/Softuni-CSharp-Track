namespace LineNumbers
{
    using System;
    using System.IO;

    class LineNumbersStart
    {
        static void Main()
        {
            using StreamReader reader = new StreamReader(Path.Combine("..", "..", "..", "Input.txt"));

            using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Output.txt"));

            int counter = 1;

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                writer.WriteLine($"{counter++}. {line}");
            }
        }
    }
}
