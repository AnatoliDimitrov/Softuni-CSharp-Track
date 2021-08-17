namespace VendingMachine
{
    using System;
    class VendingMachineStart
    {
        static void Main()
        {
            string insertedCoin = "";
            decimal insertedMoney = 0.0m;

            while ((insertedCoin = Console.ReadLine()) != "Start")
            {
                decimal coin = decimal.Parse(insertedCoin);
                if (coin != 0.1m && coin != 0.2m && coin != 0.5m && coin != 1.0m && coin != 2.0m)
                {
                    Console.WriteLine("Cannot accept {0}", coin);
                    continue;
                }
                else
                {
                    insertedMoney += coin;
                }
            }

            string purchase = "";

            while ((purchase = Console.ReadLine()) != "End")
            {
                if (purchase == "Nuts")
                {
                    if (insertedMoney - 2.0m < 0.0m)  
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Purchased nuts");
                        insertedMoney -= 2.0m;
                    }
                }
                else if (purchase == "Water")
                {
                    if (insertedMoney - 0.7m < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Purchased water");
                        insertedMoney -= 0.7m;
                    }
                }
                else if (purchase == "Crisps")
                {
                    if (insertedMoney - 1.5m < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Purchased crisps");
                        insertedMoney -= 1.5m;
                    }
                }
                else if (purchase == "Soda")
                {
                    if (insertedMoney - 0.8m < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Purchased soda");
                        insertedMoney -= 0.8m;
                    }
                }
                else if (purchase == "Coke")
                {
                    if (insertedMoney - 1.0m < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Purchased coke");
                        insertedMoney -= 1.0m;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine("Change: {0:0.00}", insertedMoney);
        }
    }
}
