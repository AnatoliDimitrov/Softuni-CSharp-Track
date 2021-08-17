using logginglibrary.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace logginglibrary
{
    public interface IError
    {
        string Date { get; }

        ReportLevel Level { get; }

        string Message { get; }
    }
}
