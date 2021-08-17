using System;

using CommandPattern.Commands;
using CommandPattern.Contracts;
using CommandPattern.Enumerators;
using CommandPattern.Models;
using CommandPattern.Modifiers;

namespace CommandPattern
{
   public class StartUp
    {
        static void Main()
        {
            var mofifyPrice = new ModifyPrice();
            var product = new Product("Phone", 500);

            Execute(product, mofifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(product, mofifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Execute(product, mofifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
