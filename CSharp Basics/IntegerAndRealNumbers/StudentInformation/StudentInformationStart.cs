namespace StudentInformation
{
    using System;
    class StudentInformationStart
    {
        static void Main()
        {
            string name = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            float grade = float.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}, Age: {1}, Grade: {2:0.00}", name, age, grade);
        }
    }
}
