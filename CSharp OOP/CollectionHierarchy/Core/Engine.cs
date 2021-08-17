using CollectionHierarchy.Models;
using System;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myListCollection = new MyList();

            Func<string, int> add = new Func<string, int>(addCollection.Add);
            Func<string, int> addRemove = new Func<string, int>(addRemoveCollection.Add);
            Func<string, int> addMyList = new Func<string, int>(myListCollection.Add);

            Console.WriteLine(ReturnIndexes(input, add));
            Console.WriteLine(ReturnIndexes(input, addRemove));
            Console.WriteLine(ReturnIndexes(input, addMyList));

            int n = int.Parse(Console.ReadLine());

            Func<string> removeFromAddRemove = new Func<string>(addRemoveCollection.Remove);
            Func<string> removeFromMyList = new Func<string>(myListCollection.Remove);

            Console.WriteLine(ReturnElements(n, removeFromAddRemove));
            Console.WriteLine(ReturnElements(n, removeFromMyList));


        }

        public string ReturnIndexes(string[] arr, Func<string, int> func)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                result.Append(func(arr[i]));
                result.Append(" ");
            }

            return result.ToString().TrimEnd();
        }

        public string ReturnElements(int n, Func<string> func)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                result.Append(func());
                result.Append(" ");
            }

            return result.ToString().TrimEnd();
        }
    }
}
