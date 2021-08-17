namespace Elevator
{
    using System;
    class ElevatorStart
    {
        static void Main()
        {
            double people = double.Parse(Console.ReadLine());
            double capacity = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling(people / capacity));
        }
    }
}
