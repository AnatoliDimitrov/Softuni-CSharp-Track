namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KeyRevolverStart
    {
        static void Main()
        {
            int buletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            var bulletsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var locksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligencePrice = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksInput);

            Stack<int> bullets = new Stack<int>(bulletsInput);

            Queue<int> newBarrel = new Queue<int>();

            Reload(bullets, newBarrel, gunBarrelSize);

            while (locks.Count > 0 && bullets.Count + newBarrel.Count > 0)
            {
                int currentBullet = newBarrel.Peek();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");

                    locks.Dequeue();

                    newBarrel.Dequeue();

                    intelligencePrice -= buletPrice;
                }
                else
                {
                    Console.WriteLine("Ping!");

                    newBarrel.Dequeue();

                    intelligencePrice -= buletPrice;
                }

                if (newBarrel.Count == 0)
                {
                    if (bullets.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Reloading!");
                    Reload(bullets, newBarrel, gunBarrelSize);
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count + newBarrel.Count} bullets left. Earned ${intelligencePrice}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }

        static void Reload(Stack<int> bullets, Queue<int> newBarrel, int gunBarrelSize)
        {
            for (int i = 0; i < gunBarrelSize; i++)
            {
                newBarrel.Enqueue(bullets.Pop());
                if (bullets.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
