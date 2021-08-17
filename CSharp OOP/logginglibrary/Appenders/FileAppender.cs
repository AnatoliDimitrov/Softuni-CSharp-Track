using System;

using logginglibrary.Enumerators;
using logginglibrary.Layouts;
using logginglibrary.LogFiles;

namespace logginglibrary.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, LogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public LogFile LogFile { get; private set; }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int ApendCounter { get; private set; }

        public void Append(string time, ReportLevel level, string message)
        {
            string log = String.Format(this.Layout.Format, time, level, message);

            if (level >= this.ReportLevel)
            {
                this.LogFile.Write(log);
                this.ApendCounter++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.ApendCounter}, File size: {this.LogFile.Size}";
        }
    }
}
