using System;
using System.IO;

namespace FolderSize
{
    class FolderSizeStart
    {
        static void Main()
        {
            string[] paths = Directory.GetFiles(Path.Combine("..","..","..", "TestFolder"));

            double sizeOfFiles = 0;

            for (int i = 0; i < paths.Length; i++)
            {
                FileInfo info = new FileInfo(paths[i]);

                sizeOfFiles += info.Length;
            }

            sizeOfFiles = sizeOfFiles / 1024 / 1024;

            using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Output.txt"));

            writer.WriteLine($"{sizeOfFiles:F14}");
        }
    }
}
