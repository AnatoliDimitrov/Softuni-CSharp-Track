namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class DirectoryTraversalStart
    {
        static void Main()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] paths = Directory.GetFiles(Console.ReadLine());

            Dictionary<string, Dictionary<string, double>> files = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in paths)
            {
                FileInfo info = new FileInfo(file);

                string extension = info.Extension;
                string name = info.Name;
                double size = info.Length / 1024d;

                if (!files.ContainsKey(extension))
                {
                    files[extension] = new Dictionary<string, double>() { { name, size} };
                }
                else
                {
                    files[extension].Add(name, size);
                }
            }

            var sorted = files
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key);

            using StreamWriter stream = new StreamWriter(path + Path.DirectorySeparatorChar + "report.txt");

            foreach (var item in sorted)
            {
                stream.WriteLine(item.Key);

                var sortedValue = item.Value
                    .OrderByDescending(v => v.Value);

                foreach (var fileInfo in sortedValue)
                {
                    stream.WriteLine($"--{fileInfo.Key} - {fileInfo.Value:F3}kb");
                }
            }
        }
    }
}
