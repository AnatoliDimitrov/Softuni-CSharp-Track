namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    class ZipAndExtractStart
    {
        static void Main()
        {
            ZipFile.CreateFromDirectory(Path.Combine("..","..","..","ToCopy"), Path.Combine("..", "..", "..", "archive", "result.zip"));
            ZipFile.ExtractToDirectory(Path.Combine("..", "..", "..", "archive", "result.zip"), Path.Combine("..", "..", "..", "unzipped"));
        }
    }
}
