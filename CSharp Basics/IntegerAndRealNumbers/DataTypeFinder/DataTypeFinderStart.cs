namespace DataTypeFinder
{
    using System;
    class DataTypeFinderStart
    {
        static void Main()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                if (int.TryParse(input, out int number))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out double floatingPoint))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (bool.TryParse(input, out bool boolean))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (char.TryParse(input, out char character))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}
