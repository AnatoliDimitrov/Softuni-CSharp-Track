using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {

        public Box(List<T> list)
        {
            this.Item = list;
        }

        public List<T> Item { get; set; }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = this.Item[firstIndex];

            this.Item[firstIndex] = this.Item[secondIndex];
            this.Item[secondIndex] = temp;
        }

        public int FindLargerElememts(T element)
        {
            int counter = 0;

            for (int i = 0; i < this.Item.Count; i++)
            {
                if (this.Item[i].CompareTo(element) == 1)
                {
                    counter++;
                }
            }
            return counter;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in this.Item)
            {
                result.AppendLine($"{item.GetType()}: {item.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
