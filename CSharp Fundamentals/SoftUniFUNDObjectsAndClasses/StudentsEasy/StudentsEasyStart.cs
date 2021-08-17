using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsEasy
{
    class StudentsEasyStart
    {
        static void Main()
        {
            List<Student> students = new List<Student>();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(" ");

                students.Add(new Student(command[0], command[1], int.Parse(command[2]), command[3]));
            }

            string city = Console.ReadLine();

            List<Student> result = students
                .Where(s => s.HomeTown == city)
                .Select(s => s)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }


        }
    }
}

