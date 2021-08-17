using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class AverageStudentGradesStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<decimal>() { grade };
                }
                else
                {
                    grades[name].Add(grade);
                }
            }

            foreach (var (StudentName, studentGrades) in grades)
            {
                string[] formatedGrades = new string[studentGrades.Count];

                for (int i = 0; i < studentGrades.Count; i++)
                {
                    formatedGrades[i] = studentGrades[i].ToString("F2");
                }
                Console.WriteLine($"{StudentName} -> {string.Join(" ", formatedGrades)} (avg: {studentGrades.Average():F2})");
            }
        }
    }
}
