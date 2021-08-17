using logginglibrary.Appenders;
using logginglibrary.Enumerators;
using logginglibrary.Layouts;
using logginglibrary.LogFiles;
using System;

namespace logginglibrary.Core
{
    public static class CommandInterpreter
    {
        public static IAppender CreateAppender(string[] appenderInfo)
        {
            string type = appenderInfo[0];
            string layoutType = appenderInfo[1];

            IAppender result = null;

            ILayout layout = null;

            if (layoutType == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else if (layoutType == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }

            if (type == "ConsoleAppender")
            {
                result = new ConsoleAppender(layout);
            }
            else if (type == "FileAppender")
            {
                result = new FileAppender(layout, new LogFile());
            }

            if (appenderInfo.Length == 3)
            {
                string levelStr = appenderInfo[2];
                ReportLevel level;
                bool isParsed = Enum.TryParse<ReportLevel>(levelStr, out level);

                if (isParsed)
                {
                    result.ReportLevel = level;
                }
            }

            return result;
        }
    }
}
