using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>> sofia = new SortedDictionary<string, System.Collections.Generic.Dictionary<string, double>>();

            string input = "";

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!sofia.ContainsKey(shop))
                {
                    sofia[shop] = new Dictionary<string, double> { {product, price } };
                }
                else
                {
                    if (!sofia[shop].ContainsKey(product))
                    {
                        sofia[shop].Add(product, price);
                    }
                    else
                    {
                        sofia[shop][product] = price;
                    }
                }
            }

            foreach (var item in sofia)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
