namespace DevidedBy7And5
{
    using System;
    class DevidedBy7And5Start
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            bool devideble = false;

            if (num % 5 == 0 && num % 7 == 0)
            {
                devideble = true;
            }

            Console.WriteLine(devideble);
        }
    }
}
