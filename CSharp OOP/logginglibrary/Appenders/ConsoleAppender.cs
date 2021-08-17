using System;

using logginglibrary.Enumerators;
using logginglibrary.Layouts;

namespace logginglibrary.Appenders
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int ApendCounter { get; private set; }

        public void Append(string time, ReportLevel level, string message)
        {
            if (level >= this.ReportLevel)
            {
                Console.WriteLine(String.Format(this.Layout.Format, time, level.ToString(), message));
                this.ApendCounter++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.ApendCounter}";
        }
    }
}
