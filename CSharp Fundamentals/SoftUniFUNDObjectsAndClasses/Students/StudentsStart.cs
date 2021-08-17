namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentsStart
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                float grade = float.Parse(input[2]);

                students.Add(new Student(input[0], input[1], grade));
            }

            students = students.OrderByDescending(st => st.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}

