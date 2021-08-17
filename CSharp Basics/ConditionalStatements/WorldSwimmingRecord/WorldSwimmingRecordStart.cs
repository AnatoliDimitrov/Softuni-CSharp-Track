namespace WorldSwimmingRecord
{
    using System;
    class WorldSwimmingRecordStart
    {
        static void Main()
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());

            double timeForDistance = distanceInMeters * secondsForMeter;
            double delay = (int)distanceInMeters / 15 * 12.5;

            timeForDistance += delay;

            if (timeForDistance < worldRecord)
            {
                Console.WriteLine("Yes, he succeeded! The new world record is {0:0.00} seconds.", timeForDistance);
            }
            else
            {
                Console.WriteLine("No, he failed! He was {0:0.00} seconds slower.", timeForDistance - worldRecord);
            }


        }
    }
}
