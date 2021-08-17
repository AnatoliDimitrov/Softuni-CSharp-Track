namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class WordCountStart
    {
        static void Main()
        {
            using Stream stream = new FileStream(Path.Combine("..", "..", "..", "text.txt"), FileMode.OpenOrCreate);

            byte[] buffer = new byte[50];

            StringBuilder text = new StringBuilder();

            List<string> words = new List<string>();

            Dictionary<string, int> counters = new Dictionary<string, int>();

            while (true)
            {
                int length = stream.Read(buffer, 0, buffer.Length);

                if (length < buffer.Length)
                {
                    var lastBuffer = new byte[length];

                    lastBuffer = buffer
                        .Take(length)
                        .ToArray();

                    InsertText(lastBuffer, text);
                    break;
                }

                InsertText(buffer, text);
            }

            using StreamReader reader = new StreamReader(Path.Combine("..", "..", "..", "words.txt"));

            using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Output.txt"), true);

            words = reader.ReadToEnd()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < words.Count; i++)
            {
                MatchCollection matches = Regex.Matches(text.ToString().ToLower(), @"\b" + words[i] + @"\b");

                counters.Add(words[i], matches.Count);
            }

            var sorted = counters
                .OrderByDescending(c => c.Value);

            foreach (var (key, value) in sorted)
            {
                writer.WriteLine($"{key} - {value}");
            }
        }

        static void InsertText(byte[] buffer, StringBuilder txt)
        {
            txt.Append(Encoding.UTF8.GetString(buffer));
        }
    }
}
