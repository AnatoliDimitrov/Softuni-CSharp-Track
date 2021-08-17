namespace FirstProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    class FirstProblemStart
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            decimal lecturesCount = decimal.Parse(Console.ReadLine());
            int initalBonus = int.Parse(Console.ReadLine());

            decimal maxBonusPoints = decimal.MinValue;
            decimal studentAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                decimal attendances = decimal.Parse(Console.ReadLine());
                decimal totalBonus = attendances / lecturesCount * (5 + initalBonus);

                if (totalBonus > maxBonusPoints)
                {
                    maxBonusPoints = totalBonus;
                    studentAttendances = attendances;
                }
            }

            if (studentsCount == 0)
            {
                maxBonusPoints = 0;
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonusPoints)}.");
            Console.WriteLine($"The student has attended {(int)studentAttendances} lectures.");
        }
    }
}
