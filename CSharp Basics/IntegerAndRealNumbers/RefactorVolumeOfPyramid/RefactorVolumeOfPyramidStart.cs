namespace RefactorVolumeOfPyramid
{
    using System;
    class RefactorVolumeOfPyramidStart
    {
        static void Main()
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double area = (length * width * height) / 3;
            Console.Write($"Pyramid Volume: {area:f2}");
        }
    }
}
