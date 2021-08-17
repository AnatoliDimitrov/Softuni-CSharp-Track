using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            if (this.Year < other.Year)
            {
                return -1;
            }
            else if (this.Year > other.Year)
            {
                return 1;
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }

    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            if (x.Title.CompareTo(y.Title) == 1)
            {
                return 1;
            }
            else if (x.Title.CompareTo(y.Title) == -1)
            {
                return -1;
            }
            else
            {
                return y.Year.CompareTo(x.Year);
            }
        }
    }
}
