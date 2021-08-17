using System;
using System.Linq;

namespace MyTuple
{
    class StartUp
    {
        static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split();
            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = string.Join(" ", firstInput.Skip(3));

            string[] secondInput = Console.ReadLine()
                .Split();
            string name = secondInput[0];
            int beer = int.Parse(secondInput[1]);
            bool drunk;

            if (secondInput[2] == "drunk")
            {
                drunk = true;
            }
            else
            {
                drunk = false;
            }

            string[] thirdInput = Console.ReadLine()
                .Split();
            string customerName = thirdInput[0];
            double balance = double.Parse(thirdInput[1]);
            string bankName = string.Join(" ", thirdInput.Skip(2));

            Threeuple<string, string, string> nameAndAddress = new Threeuple<string, string, string>(fullName, address, town);
            Threeuple<string, int, bool> nameAndBeer = new Threeuple<string, int, bool>(name, beer, drunk);
            Threeuple<string, double, string> numberAndDouble = new Threeuple<string, double, string>(customerName, balance, bankName);

            Console.WriteLine(nameAndAddress);
            Console.WriteLine(nameAndBeer);
            Console.WriteLine(numberAndDouble);
        }
    }
}
