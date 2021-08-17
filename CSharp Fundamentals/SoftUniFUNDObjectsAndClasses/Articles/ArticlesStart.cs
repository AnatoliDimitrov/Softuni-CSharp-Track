namespace Articles
{
    using System;
    class ArticlesStart
    {
        static void Main()
        {
            string[] book = Console.ReadLine().Split(", ");

            Article art = new Article(book[0], book[1], book[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                string method = command[0];
                string newValue = command[1];

                if (method == "Edit")
                {
                    art.Edit(newValue);
                }
                else if (method == "ChangeAuthor")
                {
                    art.ChangeAuthor(newValue);
                }
                else
                {
                    art.Rename(newValue);
                }
            }

            Console.WriteLine(art.ToString());
        }
    }
}

