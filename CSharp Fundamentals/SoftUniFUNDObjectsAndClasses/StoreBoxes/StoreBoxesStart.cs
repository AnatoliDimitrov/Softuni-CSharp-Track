using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class StoreBoxesStart
    {
        static void Main()
        {
            List<Box> boxes = new List<Box>();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split(" ");
                string serial = data[0];
                string itemName = data[1];
                int quantity = int.Parse(data[2]);
                decimal price = decimal.Parse(data[3]);

                boxes.Add(new Box(serial, new Item(itemName, price), quantity));
            }

            List<Box> result = boxes.OrderByDescending(b => b.BoxPrice).ToList();

            foreach (var box in result)
            {
                Console.WriteLine(box);
            }
        }
    }
}
