using System;

namespace PasswordGuess
{
    class PasswordGuessStart
    {
        static void Main()
        {
            string pass = "s3cr3t!P@ssw0rd"; // s3cr3t!P@ssw0rd

            string guess = Console.ReadLine();

            if (guess == pass)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
