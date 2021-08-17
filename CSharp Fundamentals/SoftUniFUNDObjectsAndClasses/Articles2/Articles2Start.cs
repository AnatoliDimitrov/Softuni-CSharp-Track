namespace Articles2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Articles2Start
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> list= new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] book = Console.ReadLine().Split(", ");

                list.Add(new Article(book[0], book[1], book[2]));
            }

            string order = Console.ReadLine();

            if (order == "title")
            {
                list = list.OrderBy(art => art.Title).ToList();
            }
            else if (order == "content")
            {
                list = list.OrderBy(art => art.Content).ToList();
            }
            else
            {
                list = list.OrderBy(art => art.Author).ToList();
            }
            
            foreach (var article in list)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
}