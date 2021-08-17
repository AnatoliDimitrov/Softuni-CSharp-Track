using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IteratorsAndComparators
{
    public class MyStack<T> : IEnumerable<T>
    {
        List<T> stack;
        public MyStack()
        {
            this.stack = new List<T>();
        }

        public void Pop()
        {
            if (this.stack.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                T last = stack.Last();
                this.stack.RemoveAt(this.stack.Count - 1);
            }
        }

        public void Push(params T[] input)
        {
            foreach (var item in input)
            {
                this.stack.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyStackEnumertator<T>(this.stack);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class MyStackEnumertator<T> : IEnumerator<T>
    {
        List<T> currentStack;

        private int index;

        public MyStackEnumertator(List<T> stack)
        {
            this.currentStack = new List<T>(stack);
            Reset();
        }
        public T Current => this.currentStack[this.index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index--;
            return this.index >= 0;
        }

        public void Reset()
        {
            this.index = this.currentStack.Count;
        }
    }
}
