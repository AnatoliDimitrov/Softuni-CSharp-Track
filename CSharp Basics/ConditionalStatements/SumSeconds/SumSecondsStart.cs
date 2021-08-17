namespace SumSeconds
{
    using System;
    class SumSecondsStart
    {
        static void Main()
        {
            double firstTime = double.Parse(Console.ReadLine());
            double secondTime = double.Parse(Console.ReadLine());
            double thirdTime = double.Parse(Console.ReadLine());

            double sum = firstTime + secondTime + thirdTime;

            int minutes = (int)sum / 60;
            int seconds = (int)sum % 60;
            
            if (seconds < 10)
            {
                Console.WriteLine("{0}:0{1}", minutes, seconds);
            }
            else
            {
                Console.WriteLine("{0}:{1}", minutes, seconds);
            }
        }
    }
}
