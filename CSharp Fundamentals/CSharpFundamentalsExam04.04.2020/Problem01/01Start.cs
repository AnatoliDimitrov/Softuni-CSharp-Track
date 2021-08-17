using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;

namespace Problem01
{
    class _01Start
    {
        static void Main()
        {
            string key = Console.ReadLine();

            string input = "";

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] instructions = input.Split(">>>", StringSplitOptions.None);
                string command = instructions[0];

                if (command == "Contains")
                {
                    string sub = instructions[1];
                    if (key.Contains(sub))
                    {
                        Console.WriteLine($"{key} contains {sub}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string action = instructions[1];
                    int start = int.Parse(instructions[2]);
                    int end = int.Parse(instructions[3]);
                    string substr = key.Substring(start, end - start);

                    if (action == "Upper")
                    {
                        substr = substr.ToUpper();
                        key = key.Remove(start, end - start);
                        key = key.Insert(start, substr);
                        Console.WriteLine(key);
                    }
                    else
                    {
                        for (int j = start; j < end; j++)
                        {
                            substr = substr.ToLower();
                            key = key.Remove(start, end - start);
                            key = key.Insert(start, substr);
                        }
                        Console.WriteLine(key);
                    }
                }
                else if (command == "Slice")
                {
                    int start = int.Parse(instructions[1]);
                    int end = int.Parse(instructions[2]);
                    key = key.Remove(start, end - start);
                    Console.WriteLine(key);
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
