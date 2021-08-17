using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class SimpleTextEditorStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> ditto = new Stack<string>();

            string text = "";

            for (int i = 0; i < n; i++)
            {
                string[] instructions = Console.ReadLine().Split();
                string command = instructions[0];

                if (command == "1")
                {
                    string current = instructions[1];

                    ditto.Push(text);
                    text += current;
                }
                else if (command == "2")
                {
                    int len = int.Parse(instructions[1]);

                    ditto.Push(text);
                    text = text.Substring(0, text.Length - len);
                }
                else if (command == "3")
                {
                    int index = int.Parse(instructions[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    text = ditto.Pop();
                }
            }
        }
    }
}
