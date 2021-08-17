namespace CopyBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    class CopyBinaryFileStart
    {
        static void Main()
        {
            using FileStream streamInput = new FileStream(Path.Combine("..", "..", "..", "copyMe.png"), FileMode.OpenOrCreate);

            using FileStream streamOutput = new FileStream(Path.Combine("..", "..", "..", "copied.png"), FileMode.OpenOrCreate);

            byte[] buffer = new byte[4096];

            while (true)
            {
                int read = streamInput.Read(buffer, 0, buffer.Length);

                if (read < buffer.Length)
                {
                    byte[] lastRead = new byte[read];

                    lastRead = buffer
                        .Take(read)
                        .ToArray();

                    streamOutput.Write(lastRead);

                    break;
                }

                streamOutput.Write(buffer);
            }
        }
    }
}
