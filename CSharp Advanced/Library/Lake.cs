using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Lake<T> : IEnumerable<T>
    {
        List<T> list;

        public Lake(params T[] stones)
        {
            this.list = new List<T>(stones);
        }
        public IEnumerator<T> GetEnumerator()
        {
            List<T> currentList = new List<T>();
            Stack<T> currentStack = new Stack<T>();

            for (int i = 0; i < this.list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    currentList.Add(this.list[i]);
                }
                else if (i % 2 != 0)
                {
                    currentStack.Push(this.list[i]);
                }
            }

            foreach (var item in currentList)
            {
                yield return item;
            }

            foreach (var item in currentStack)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
