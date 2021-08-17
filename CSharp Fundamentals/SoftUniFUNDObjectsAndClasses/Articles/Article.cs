using System;
using System.Collections.Generic;
using System.Text;

namespace Articles
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

        public void Edit(string value)
        {
            Content = value;
        }

        public void ChangeAuthor(string value)
        {
            Author = value;
        }

        public void Rename(string value)
        {
            Title = value;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
