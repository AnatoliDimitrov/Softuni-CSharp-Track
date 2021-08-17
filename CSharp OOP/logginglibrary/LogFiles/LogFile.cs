using System;
using System.Linq;
using System.IO;

namespace logginglibrary.LogFiles
{
    public class LogFile : ILogFile
    {
        private const string filePath = @"../../../log.txt";
        public long Size => GetFileSize();

        public void Write(string message)
        {
            File.AppendAllText(filePath, message);
        }

        private long GetFileSize()
        {
            return File.ReadAllText(filePath)
                .Where(char.IsLetter)
                .Sum(c => c);
        }
    }
}
