namespace ThirdProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    class ThirdProblemStart
    {
        static void Main()
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            string input = "";

            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] commands = input.Split(" - ");
                string command = commands[0];
                if (command == "Collect")
                {
                    string item = commands[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    string item = commands[1];
                    int index = items.IndexOf(item);
                    if (index >= 0)
                    {
                        items.RemoveAt(index);
                    }
                }
                else if (command == "Combine Items")
                {
                    string[] item = commands[1].Split(":");
                    string old = item[0];
                    string newItem = item[1];

                    int index = items.IndexOf(old);
                    if (index >= 0)
                    {
                        items.Insert(index + 1, newItem);
                    }
                }
                else
                {
                    string item = commands[1];
                    int index = items.IndexOf(item);
                    if (index >= 0)
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ",items));
        }
    }
}
