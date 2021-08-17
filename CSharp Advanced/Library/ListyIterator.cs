using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;

        private List<T> list;
        public ListyIterator(params T[] input)
        {
            this.list = new List<T>(input);
        }

        public bool Move()
        {
            if (this.index < this.list.Count - 1)
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.list.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(this.list[this.index]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
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
