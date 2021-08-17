namespace RectangleArea
{
    using System;
    class RectangleAreaStart
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = width * height;

            Console.WriteLine("{0:0.00}",area);
        }
    }
}
