using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBoxes
{
    public class Box
    {
        public string Serial { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal BoxPrice { get; set; }

        public Box(string serial, Item item, int quantity)
        {
            this.Serial = serial;
            this.Quantity = quantity;
            this.Item = item;
            this.BoxPrice = Quantity * Item.Price;
        }

        public override string ToString()
        {
            return $"{this.Serial}\n-- {this.Item.Name} - ${this.Item.Price:f2}: {this.Quantity}\n-- ${this.BoxPrice:f2}";
        }
    }
}
