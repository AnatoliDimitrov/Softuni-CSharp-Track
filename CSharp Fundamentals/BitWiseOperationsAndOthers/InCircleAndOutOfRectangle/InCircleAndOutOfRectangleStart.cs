namespace InCircleAndOutOfRectangle
{
    using System;
    class InCircleAndOutOfRectangleStart
    {
        static void Main()
        {
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());

            double circleCenterX = 1;
            double circleCenterY = 1;
            double distance = 5;

            bool insideCircle = false;
            bool insideRectangle = false;

            double result = Math.Sqrt(Math.Pow(pointX - circleCenterX, 2) + Math.Pow(pointY - circleCenterY, 2));

            if (result <= distance)
            {
                insideCircle = true;
            }

            if (!(pointX <= 1 && pointX >= -1 && pointY >= -1 && pointY <= 5))
            {
                insideRectangle = true;
            }

            if (insideCircle && insideRectangle)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
