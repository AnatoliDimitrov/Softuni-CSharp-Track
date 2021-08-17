namespace MergeFiles
{
    using System.IO;

    class MergeFilesStart
    {
        static void Main()
        {
            using StreamReader readerFirstFile = new StreamReader(Path.Combine("..", "..", "..", "Input1.txt"));

            using StreamReader readerSecondFile = new StreamReader(Path.Combine("..", "..", "..", "Input2.txt"));

            using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Output.txt"));

            while (true)
            {
                string lineOfFirst = readerFirstFile.ReadLine();
                string lineOfSecond = readerSecondFile.ReadLine();

                if (lineOfFirst != null)
                {
                    writer.WriteLine(lineOfFirst);
                }

                if (lineOfSecond != null)
                {
                    writer.WriteLine(lineOfSecond);
                }

                if (lineOfFirst == null && lineOfSecond == null)
                {
                    break;
                }
            }
        }
    }
}
