namespace SliceAFile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    class SliceAFileStart
    {
        static void Main()
        {
            using Stream stream = new FileStream(Path.Combine("..", "..", "..", "sliceMe.txt"), FileMode.OpenOrCreate);

            int length = (int)Math.Ceiling(stream.Length / 4.0);

            byte[] buffer = new byte[length];

            int counter = 1;

            while (true)
            {
                int readCount = stream.Read(buffer, 0, buffer.Length);

                using StreamWriter writer = new StreamWriter(Path.Combine("..", "..", "..", "Part-" + counter + @".txt"));

                if (readCount < length)
                {
                    byte[] lastBuffer = new byte[readCount];

                    lastBuffer = buffer
                        .Take(readCount)
                        .ToArray();

                    Write(writer, lastBuffer);
                    break;
                }

                Write(writer, buffer);

                counter++;
            }
        }

        static void Write(StreamWriter writer, byte[] buffer)
        {
            string txt = Encoding.UTF8.GetString(buffer);

            writer.Write(txt);
        }
    }
}
