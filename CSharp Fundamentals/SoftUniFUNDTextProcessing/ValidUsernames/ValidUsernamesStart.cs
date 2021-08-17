using System;

namespace ValidUsernames
{
    class ValidUsernamesStart
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                if (Validate(input[i]))
                {
                    Console.WriteLine(input[i]);
                }
            }
        }

        private static bool Validate(string userName)
        {
            bool isValid = true;

            if (userName.Length < 3 || userName.Length > 16)
            {
                return false;
            }
            for (int i = 0; i < userName.Length; i++)
            {
                char c = userName[i];
                if (!char.IsLetterOrDigit(c) && c != '-' && c != '_')
                {
                    return false;
                }
            }

            return isValid;
        }
    }
}
