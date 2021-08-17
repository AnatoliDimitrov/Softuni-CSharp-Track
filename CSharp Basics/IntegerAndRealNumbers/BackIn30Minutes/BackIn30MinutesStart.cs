﻿namespace BackIn30Minutes
{
    using System;
    class BackIn30MinutesStart
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;
            if (minutes > 59)
            {
                minutes -= 60;
                if (hours == 23)
                {
                    hours = 0;
                }
                else
                {
                    hours++;
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
