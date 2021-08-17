using System.Collections.Generic;

using logginglibrary.Appenders;

namespace logginglibrary.Loogers
{
    interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Info(string date, string message);

        void Warning(string date, string message);

        void Error(string date, string message);

        void Critical(string date, string message);

        void Fatal(string date, string message);
    }
}
