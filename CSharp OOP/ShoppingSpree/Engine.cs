using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingSpree
{
    class Engine
    {
        public void Run()
        {
            string[] clientsData = Splitter(Console.ReadLine());

            string[] productsData = Splitter(Console.ReadLine());

            var persons = PersonsCreator(clientsData);

            var products = ProductsCreator(productsData);

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string buyerName = info[0];
                string productName = info[1];

                Person buyer = persons[buyerName];
                Product product = products[productName];

                try
                {
                    buyer.Buy(product);
                    Console.WriteLine($"{buyerName} bought {productName}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            foreach (var item in persons)
            {
                Console.WriteLine($"{item.Key} - {item.Value.PrintBag()}");
            }
        }

        private string[] Splitter(string items)
        {
            return items.
                Split(";", StringSplitOptions.RemoveEmptyEntries);
        }

        private Dictionary<string, Person> PersonsCreator(string[] persons)
        {
            Dictionary<string, Person> result = new Dictionary<string, Person>();
            for (int i = 0; i < persons.Length; i++)
            {
                string[] personData = persons[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                Person person = new Person(name, money);

                result.Add(name, person);
            }

            return result;
        }

        private Dictionary<string, Product> ProductsCreator(string[] products)
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();
            for (int i = 0; i < products.Length; i++)
            {
                string[] productData = products[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = productData[0];
                decimal cost = decimal.Parse(productData[1]);

                Product product = new Product(name, cost);

                result.Add(name, product);
            }

            return result;
        }
    }
}
