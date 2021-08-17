using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class UniqueUsernamesStart
    {
        static void Main()
        {
            HashSet<string> usernames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
