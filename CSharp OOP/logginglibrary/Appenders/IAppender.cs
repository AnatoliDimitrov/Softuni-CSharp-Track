using logginglibrary.Enumerators;
using logginglibrary.Layouts;

namespace logginglibrary.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }
        void Append(string time, ReportLevel level, string message);
    }
}
