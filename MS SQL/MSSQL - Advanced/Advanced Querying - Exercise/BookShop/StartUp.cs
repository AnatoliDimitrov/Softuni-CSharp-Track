using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Z.EntityFramework.Plus;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            //Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(Console.ReadLine())));
            //Console.WriteLine(GetBooksByCategory(db, Console.ReadLine()));
            //Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()));
            //Console.WriteLine(GetAuthorNamesEndingIn(db, Console.ReadLine()));
            //Console.WriteLine(GetBookTitlesContaining(db, Console.ReadLine()));
            //Console.WriteLine(GetBooksByAuthor(db, Console.ReadLine()));
            //Console.WriteLine(CountBooks(db, int.Parse(Console.ReadLine())));
            //Console.WriteLine(CountCopiesByAuthor(db));
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            Console.WriteLine(RemoveBooks(db));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var result = new StringBuilder();

            context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList()
                .ForEach(b => result.AppendLine(b));
            
            return result.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Books
                .Where(b => b.EditionType == Enum.Parse<EditionType>("Gold") && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList()
                .ForEach(t => result.AppendLine(t));

            return result.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Books
                .Where(b => b.Price > 40.0m)
                .OrderByDescending(b => b.Price)
                .Select(b => new {b.Title, b.Price})
                .ToList()
                .ForEach(b => result.AppendLine($"{b.Title} - ${b.Price:f2}"));

            return result.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = new StringBuilder();

            context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList()
                .ForEach(b => result.AppendLine(b));

            return result.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            context.BooksCategories
                .Where(bc => input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.ToLower())
                    .ToList().Contains(bc.Category.Name.ToLower()))
                .Select(b => b.Book.Title)
                .OrderBy(t => t)
                .ToList()
                .ForEach(t => result.AppendLine(t));

            return result.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var result = new StringBuilder();

            context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title, b.EditionType, b.Price
                })
                .ToList()
                .ForEach(b => result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}"));

            return result.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new{FullName = a.FirstName + " " + a.LastName})
                .OrderBy(a => a.FullName)
                .ToList()
                .ForEach(f => result.AppendLine(f.FullName));

            return result.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList()
                .ForEach(t => result.AppendLine(t));

            return result.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            context.Books
                .Select(b => new
                {
                    b.Title,
                    b.BookId,
                    b.Author
                })
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList()
                .ForEach(b => result.AppendLine($"{b.Title} ({b.Author.FirstName} {b.Author.LastName})"));

            return result.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Authors
                .Select( a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    BooksCopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BooksCopiesCount)
                .ToList()
                .ForEach(a => result.AppendLine($"{a.FullName} - {a.BooksCopiesCount}"));

            return result.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalPrice = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.TotalPrice)
                .ThenBy(c => c.Name)
                .ToList()
                .ForEach(c => result.AppendLine($"{c.Name} ${c.TotalPrice:f2}"));


            return result.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate.Value)
                        .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5.00m;
            }

            context.BulkSaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksCount = context.Books.Count(b => b.Copies < 4200);

            context.Books
                .Where(b => b.Copies < 4200)
                .Delete();

            return booksCount;
        }
    }
}
