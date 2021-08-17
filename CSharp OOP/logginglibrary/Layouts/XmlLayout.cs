using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace logginglibrary.Layouts
{
    class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("<log>");
            result.AppendLine("<date>{0}</date>");
            result.AppendLine("<level>{1}</level>");
            result.AppendLine("<message>{2}</message>");
            result.AppendLine("</log>");

            return result.ToString();
        }
    }
}
