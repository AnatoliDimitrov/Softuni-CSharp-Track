namespace TimeWith15Minutes
{
    using System;
    class TimeWith15MinutesStart
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes + 15 == 60)
            {
                hours++;
                if (hours == 24)
                {
                    hours = 0;
                }
                minutes = 0;
            }
            else if (minutes + 15 <= 59)
            {
                minutes += 15;
            }
            else if (minutes + 15 > 60)
            {
                minutes = (minutes + 15) - 60;
                hours++;
                if (hours == 24)
                {
                    hours = 0;
                }
            }

            if (minutes < 10)
            {
                Console.WriteLine("{0}:0{1}", hours, minutes);
            }
            else
            {
                Console.WriteLine("{0}:{1}", hours, minutes);
            }
        }
    }
}
