using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
            set { name = ValidateName(value); }
        }

        public decimal Cost
        {
            get { return cost; }
            set { cost = ValidatePrice(value); }
        }


        private string ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || name == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }

            return name;
        }

        private decimal ValidatePrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            return price;
        }
    }
}
