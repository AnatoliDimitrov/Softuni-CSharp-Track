using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem01
{
    class StartUp
    {
        static void Main()
        {
            int[] firstInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> effects = new Queue<int>(firstInput);

            Stack<int> casings = new Stack<int>(secondInput);

            Dictionary<int, string> bombs = new Dictionary<int, string>()
            {
               {40, "Datura Bombs"},
               {60, "Cherry Bombs"},
               {120, "Smoke Decoy Bombs"}
            };

            Dictionary<string, int> pouch = new Dictionary<string, int>()
            {
               {"Cherry Bombs", 0},
               {"Datura Bombs", 0},
               {"Smoke Decoy Bombs", 0}
            };

            bool done = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int sumTemp = effects.Peek() + casings.Peek();

                if (bombs.ContainsKey(sumTemp))
                {
                    pouch[bombs[sumTemp]]++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    int bombCasing = casings.Pop();
                    casings.Push(bombCasing - 5);
                }

                done = IsFullPouch(pouch);

                if (done)
                {
                    break;
                }
            }

            if (done)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            foreach (var (key, value) in pouch)
            {
                Console.WriteLine($"{key}: {value}");
            }
        }

        public static bool IsFullPouch(Dictionary<string, int> pouch)
        {
            foreach (var (key, value) in pouch)
            {
                if (value < 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
