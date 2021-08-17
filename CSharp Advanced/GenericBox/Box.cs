using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GenericBox
{
    public class Box<T>
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
