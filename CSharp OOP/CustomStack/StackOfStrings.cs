using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddRange(Stack<string> toAdd)
        {
            foreach (var item in toAdd)
            {
                this.Push(item);
            }
        }
    }
}
