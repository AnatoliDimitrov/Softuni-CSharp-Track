using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class BalancedParenthesisStart
    {
        static void Main()
        {
            string parenthesis = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < parenthesis.Length; i++)
            {
                if (CheckOpen(parenthesis[i]))
                {
                    stack.Push(parenthesis[i]);
                }
                else if (stack.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (parenthesis[i] == ')' && stack.Pop() == '(')
                {
                    continue;
                }
                else if (parenthesis[i] == ']' && stack.Pop() == '[')
                {
                    continue;
                }
                else if (parenthesis[i] == '}' && stack.Pop() == '{')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        static bool CheckOpen(char current) 
        {
            List<char> chars = new List<char> { '(', '[', '{' };
            if (chars.Contains(current))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
