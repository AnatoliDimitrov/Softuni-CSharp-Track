namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class DateModifier
    {
        public int TakeDateDifference(string firstDate, string secondDate)
        {
            DateTime first = new DateTime();
            first = DateTime.Parse(firstDate);

            DateTime second = new DateTime();
            second = DateTime.Parse(secondDate);

            if (first > second)
            {
                return (first - second).Days;
            }
            else
            {
                return (second - first).Days;
            }
        }
    }
}
