namespace SecondProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    class SecondProblemStart
    {
        static void Main()
        {
            List<string> rooms = Console.ReadLine().Split("|").ToList();

            double health = 100;
            double coins = 0;

            for (int i = 0; i < rooms.Count; i++)
            {
                string[] data = rooms[i].Split(" ");
                string type = data[0];
                double points = double.Parse(data[1]);

                if (type == "potion")
                {
                    if (health == 100)
                    {
                        Console.WriteLine($"You healed for {0} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (health + points <= 100)
                    {
                        health += points;
                        Console.WriteLine($"You healed for {points} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (health + points  > 100)
                    {

                        double temp = 100 - health;
                        points += health;
                        
                        Console.WriteLine($"You healed for {temp} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (type == "chest")
                {
                    Console.WriteLine($"You found {points} bitcoins.");
                    coins += points;
                }
                else
                {
                    health -= points;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {type}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {type}.");
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {coins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
