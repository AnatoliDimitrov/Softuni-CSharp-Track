namespace BeerKegs
{
    using System;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string modelOfBiggets = "";
            double volume = 0;

            for (int i = 0; i < n; i++)
            {
                string modelName = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentVolume = Math.PI * Math.Pow(radius, 2) * height;
                if (currentVolume > volume)
                {
                    volume = currentVolume;
                    modelOfBiggets = modelName;
                }

            }
            Console.WriteLine(modelOfBiggets);
        }
    }
}
