using logginglibrary.Enumerators;

namespace logginglibrary
{
    class Error : IError
    {
        public Error(string date, ReportLevel level, string message)
        {
            this.Date = date;
            this.Level = level;
            this.Message = message;
        }
        public string Date { get; private set; }

        public ReportLevel Level{ get; private set; }

        public string Message { get; private set; }
    }
}
