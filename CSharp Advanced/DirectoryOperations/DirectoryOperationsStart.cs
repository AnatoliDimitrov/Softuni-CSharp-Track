using System;
using System.IO;

namespace DirectoryOperations
{
    class DirectoryOperationsStart //not working
    {
        static void Main()
        {
            string path = @"C:\Users\apdim\Desktop\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size";

            long size = FindAllFiles(path, 0);

            Console.WriteLine($"{size}");

            using StreamWriter writer = new StreamWriter(@"C:\Users\apdim\Desktop\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size\output.txt");

            writer.WriteLine($"The size of the folder \"06. Folder Size\" is {(size / 1024m / 1024m):F1} MB");
        }

        static long FindAllFiles(string path, long length)
        {
            string[] directories = Directory.GetDirectories(path);

            foreach (string directory in directories)
            {
                string[] files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    length += info.Length;
                }
               length = FindAllFiles(directory, length);
            }
            Console.WriteLine($"{(length/1024m/1024m):F1}");

            return length;
        }
    }
}
