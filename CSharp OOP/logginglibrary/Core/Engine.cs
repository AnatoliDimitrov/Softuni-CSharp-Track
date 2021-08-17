using logginglibrary.Appenders;
using logginglibrary.Enumerators;
using logginglibrary.Loogers;
using System;
using System.Collections.Generic;
using System.Text;

namespace logginglibrary.Core
{
    class Engine : IEngine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] appenderInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                appenders.Add(CommandInterpreter.CreateAppender(appenderInfo));
            }

            var logger = new Logger(appenders.ToArray());

            List<IError> errors = new List<IError>();

            string InputError = "";

            while ((InputError = Console.ReadLine()) != "END")
            {
                string[] errorInfo = InputError
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                ReportLevel level;

                bool isParsed = Enum.TryParse<ReportLevel>(errorInfo[0], out level);

                string date = errorInfo[1];
                string message = errorInfo[2];

                errors.Add(new Error(date, level, message));
            }

            foreach (var error in errors)
            {
                string date = error.Date;
                string message = error.Message;

                if (error.Level.ToString() == "INFO")
                {
                    logger.Info(date, message);
                }
                else if (error.Level.ToString() == "WARNING")
                {
                    logger.Warning(date, message);
                }
                else if (error.Level.ToString() == "ERROR")
                {
                    logger.Error(date, message);
                }
                else if (error.Level.ToString() == "CRITICAL")
                {
                    logger.Critical(date, message);
                }
                else if (error.Level.ToString() == "FATAL")
                {
                    logger.Fatal(date, message);
                }
            }

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
