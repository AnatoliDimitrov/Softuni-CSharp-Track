namespace PointInsideCircle
{
    using System;
    class PointInsideCircleStart
    {
        static void Main()
        {
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());

            double center = 0;
            double distance = 5;

            double result = Math.Sqrt(Math.Pow(pointX - center, 2) + Math.Pow(pointY - center, 2));

            if (result <= distance)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
