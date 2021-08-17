namespace Login
{
    using System;
    class LoginStart
    {
        static void Main()
        {
            string user = Console.ReadLine();
            string pass = ReverseString(user);
            string input = "";
            int counter = 0;



            while ((input = Console.ReadLine()) != pass)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine("User {0} blocked!", user);
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }

            Console.WriteLine("User {0} logged in.", user);
        }

        public static string ReverseString(string user)
        {
            char[] arr = user.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
