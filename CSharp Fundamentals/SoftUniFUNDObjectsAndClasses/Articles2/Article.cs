using System;
using System.Collections.Generic;
using System.Text;

namespace Articles2
{
    public class Article
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public string Author { get; private set; }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
