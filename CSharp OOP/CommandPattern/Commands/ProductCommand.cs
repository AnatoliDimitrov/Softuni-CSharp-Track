using CommandPattern.Contracts;
using CommandPattern.Enumerators;
using CommandPattern.Models;
using System;

namespace CommandPattern.Commands
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceAction action, int amount)
        {
            this.product = product;
            this.priceAction = action;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            if (this.priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(this.amount);
            }
            else
            {
                product.DecreasePrice(this.amount);
            }
        }
    }
}
