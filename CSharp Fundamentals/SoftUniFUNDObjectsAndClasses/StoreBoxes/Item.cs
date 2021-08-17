using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBoxes
{
    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
