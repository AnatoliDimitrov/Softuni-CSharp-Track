using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Shape rectangle = new Rectangle(5, 5);
            Shape circle = new Circle(5);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
