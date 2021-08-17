using System;
using System.IO;

namespace LineNumbersExercise
{
    class LineNumbersExerciseStart
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines(Path.Combine("..", "..", "..", "text.txt"));

            using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Output.txt"));

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int letters = 0;
                int punctuationMarks = 0;

                for (int j = 0; j < line.Length; j++)
                {
                    if (char.IsLetter(line[j]))
                    {
                        letters++;
                    }
                    else if (char.IsPunctuation(line[j]))
                    {
                        punctuationMarks++;
                    }
                }

                writer.WriteLine($"Line {i + 1}: {line} ({letters})({punctuationMarks})");
            }
        }
    }
}
