using System;
using System.Collections.Generic;
using System.Linq;

namespace Student2
{
    class Student2Start
    {
        static void Main()
        {
            List<Student> students = new List<Student>();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(" ");

                var checkName = students.Find(s => s.FirstName == command[0] && s.LastName == command[1]);
                if (checkName == null)
                {
                    students.Add(new Student(command[0], command[1], int.Parse(command[2]), command[3]));
                }
                else
                {
                    checkName.FirstName = command[0];
                    checkName.LastName = command[1];
                    checkName.Age = int.Parse(command[2]);
                    checkName.HomeTown = command[3];

                }
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
