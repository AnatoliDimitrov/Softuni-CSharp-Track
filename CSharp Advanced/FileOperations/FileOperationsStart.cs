namespace FileOperations
{
    using System;
    using System.IO;
    class FileOperationsStart
    {
        static void Main()
        {
            using StreamReader reader = new StreamReader(@"C:\Users\apdim\Desktop\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\01. Odd Lines\input.txt");

            using StreamWriter writer = new StreamWriter(@"C:\Users\apdim\Desktop\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\01. Odd Lines\output.txt");

            int counter = 0;

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 1)
                {
                    writer.WriteLine(line, true);
                }

                counter++;
            }
        }
    }
}
