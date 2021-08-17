using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        private decimal money;

        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = bagOfProducts;
        }

        public string Name
        {
            get { return name; }
            private set { name = ValidateName(value); }
        }

        public decimal Money
        {
            get { return money; }
            private set { money = ValidateMoneyBalance(value); }
        }

        public List<Product> Bag
        {
            get
            {
                return bagOfProducts;
            }
            private set
            {
                this.bagOfProducts = new List<Product>();
            }
        }


        private string ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || name == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }

            return name;
        }

        private decimal ValidateMoneyBalance(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            return money;
        }

        public void Buy(Product product)
        {
            if (this.Money - product.Cost < 0)
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.Bag.Add(product);
                this.Money -= product.Cost;
            }
        }

        public string PrintBag()
        {
            if (this.Bag.Count == 0)
            {
                return "Nothing bought";
            }

            List<string> names = new List<string>();

            foreach (var item in this.Bag)
            {
                names.Add(item.Name);
            }

            return string.Join(", ", names);
        }
    }
}
