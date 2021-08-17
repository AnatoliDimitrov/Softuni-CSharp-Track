using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            string input = "";

            List<Visitor> visitors = new List<Visitor>(); 

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (info.Length == 2)
                {
                    Robot robot = new Robot(info[0], info[1]);
                    visitors.Add(robot);
                }
                else
                {
                    Citizen citizen = new Citizen(info[0], int.Parse(info[1]), info[2]);
                    visitors.Add(citizen);
                }
            }

            string idEnd = Console.ReadLine();

            foreach (var visitor in visitors)
            {
                if (visitor.Id.EndsWith(idEnd))
                {
                    Console.WriteLine(visitor.Id);
                }
            }
        }
    }
}
