using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class SoftUniPartyStart
    {
        static void Main()
        {
            HashSet<string> VIPNumbers = new HashSet<string>();
            HashSet<string> regularNumbers = new HashSet<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    VIPNumbers.Add(input);
                }
                else
                {
                    regularNumbers.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    if (VIPNumbers.Contains(input))
                    {
                        VIPNumbers.Remove(input);
                    }
                }
                else
                {
                    if (regularNumbers.Contains(input))
                    {
                        regularNumbers.Remove(input);
                    }
                }
            }

            Console.WriteLine(VIPNumbers.Count + regularNumbers.Count);

            foreach (var vip in VIPNumbers)
            {
                Console.WriteLine(vip);
            }

            foreach (var regular in regularNumbers)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
