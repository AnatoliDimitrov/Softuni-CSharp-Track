namespace GamingStore
{
    using System;
    class GamingStoreStart
    {
        static void Main()
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal beginsBudget = budget;
            string input = "";

            while ((input = Console.ReadLine()) != "Game Time")
            {
                if (input == "OutFall 4")
                {
                    if (budget - 39.99m < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        budget -= 39.99m;
                        Console.WriteLine("Bought OutFall 4");
                    }
                }
                else if (input == "CS: OG")
                {
                    if (budget - 15.99m < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        budget -= 15.99m;
                        Console.WriteLine("Bought CS: OG");
                    }
                }
                else if (input == "Zplinter Zell")
                {
                    if (budget - 19.99m < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        budget -= 19.99m;
                        Console.WriteLine("Bought Zplinter Zell");
                    }
                }
                else if (input == "Honored 2")
                {
                    if (budget - 59.99m < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        budget -= 59.99m;
                        Console.WriteLine("Bought Honored 2");
                    }
                }
                else if (input == "RoverWatch")
                {
                    if (budget - 29.99m < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        budget -= 29.99m;
                        Console.WriteLine("Bought RoverWatch");
                    }
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    if (budget - 39.99m < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        budget -= 39.99m;
                        Console.WriteLine("Bought RoverWatch Origins Edition");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }
            Console.WriteLine("Total spent: ${0:0.00}. Remaining: ${1:0.00}", beginsBudget - budget, budget);
        }
    }
}

//else if (budget - 39.99m == 0)
//{
//    Console.WriteLine("Out of money!");
//}