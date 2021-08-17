namespace SongsQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class SongsQueueStart
    {
        static void Main()
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string input = Console.ReadLine();

                if (input.StartsWith("Add"))
                {
                    string song = input.Replace("Add ", "");

                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (input == "Play" && queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
