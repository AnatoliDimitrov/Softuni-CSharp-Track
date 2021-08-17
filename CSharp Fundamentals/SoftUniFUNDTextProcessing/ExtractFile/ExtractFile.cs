using System;

namespace ExtractFile
{
    class ExtractFile
    {
        static void Main()
        {
            string[] path = Console.ReadLine().Split('\\', '/' );

            string[] file = path[path.Length - 1].Split(".");

            string name = file[0];
            string extension = file[1];

            Console.WriteLine("File name: {0}", name);
            Console.WriteLine("File extension: {0}", extension);
        }
    }
}
