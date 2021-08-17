using System;
using System.Collections.Generic;

using logginglibrary.Appenders;
using logginglibrary.Enumerators;

namespace logginglibrary.Loogers
{
    class Logger : ILogger
    {
        ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders 
        {
            get 
            {
                return (IReadOnlyCollection<IAppender>)appenders;
            }
            private set
            {
                this.appenders = (ICollection<IAppender>)value;
            } 
        }


        public void Info(string date, string message)
        {
            ReportLevel level = ReportLevel.INFO;

            GetAppenders(date, message, level);
        }

        public void Warning(string date, string message)
        {
            ReportLevel level = ReportLevel.WARNING;

            GetAppenders(date, message, level);
        }

        public void Error(string date, string message)
        {
            ReportLevel level = ReportLevel.ERROR;

            GetAppenders(date, message, level);
        }

        public void Critical(string date, string message)
        {
            ReportLevel level = ReportLevel.CRITICAL;

            GetAppenders(date, message, level);
        }

        public void Fatal(string date, string message)
        {
            ReportLevel level = ReportLevel.FATAL;

            GetAppenders(date, message, level);
        }

        private void GetAppenders(string date, string message, ReportLevel level)
        {
            foreach (var appender in appenders)
            {
                appender.Append(date, level, message);
            }
        }
    }
}
