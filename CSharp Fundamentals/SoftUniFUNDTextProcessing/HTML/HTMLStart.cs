using System;

namespace HTML
{
    class HTMLStart
    {
        static void Main()
        {


            string title = Console.ReadLine();
            Console.WriteLine("<h1>\n" + "\t" + title + "\n</h1>");

            string content = Console.ReadLine();
            Console.WriteLine("<article>\n" + "\t" + content + "\n</article>");

            string comment = "";

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                Console.WriteLine("<div>\n" + "\t" + comment + "\n</div>");
            }
        }
    }
}
