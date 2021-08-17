namespace Messages
{
    using System;
    using System.Text;

    class MessagesStart
    {
        static void Main()
        {
            int len = int.Parse(Console.ReadLine());
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                string input = Console.ReadLine();
                if (input == "0")
                {
                    word.Append(" ");
                }
                else
                {
                    int mainDigit = int.Parse(input[0].ToString());
                    int length = input.Length;
                    int offSet = (mainDigit - 2) * 3;

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offSet++;
                    }

                    int digit = offSet + length - 1;
                    char letter = (char)(digit + 97);

                    word.Append(letter);


                }
            }
            Console.WriteLine(word);
        }
    }
}
