namespace DecryptingMessages
{
    using System;
    using System.Text;

    class DecryptingMessagesStart
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int linesCount = int.Parse(Console.ReadLine());

            StringBuilder decrypted = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                char input = char.Parse(Console.ReadLine());
                input = (char)(input + key);

                decrypted.Append(input);
            }
            Console.WriteLine(decrypted);
        }
    }
}
