using System;

using logginglibrary.Appenders;
using logginglibrary.Core;
using logginglibrary.Enumerators;
using logginglibrary.Layouts;
using logginglibrary.LogFiles;
using logginglibrary.Loogers;

namespace logginglibrary
{
    class StartUp
    {
        static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
