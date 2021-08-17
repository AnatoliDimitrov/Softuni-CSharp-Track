namespace Scholarship
{
    using System;
    class ScholarshipStart
    {
        static void Main()
        {
            double income = double.Parse(Console.ReadLine());
            double result = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScholarship = 0.0;
            double successScholarship = 0.0;

            if (result < 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
                return;
            }
            if (result > 4.5 && result < 5.5 && income > minimalSalary)
            {
                Console.WriteLine("You cannot get a scholarship!");
                return;
            }

            if (result > 4.50 && income <= minimalSalary && result < 5.5)
            {
                socialScholarship = minimalSalary * 0.35;
            }

            if (result >= 5.50)
            {
                successScholarship = result * 25;
            }

            if (socialScholarship > successScholarship)
            {
                Console.WriteLine("You get a Social scholarship {0} BGN", (int)socialScholarship);
            }
            else
            {
                Console.WriteLine("You get a scholarship for excellent results {0} BGN", (int)successScholarship);
            }

        }
    }
}
