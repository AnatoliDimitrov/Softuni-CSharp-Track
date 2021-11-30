using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                        .Select(ab => ab.Book)
                        .OrderByDescending(b => b.Price)
                        .Select(b => new
                        {
                            BookName = b.Name,
                            BookPrice = b.Price.ToString("f2"),
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBookXmlDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Books
                .ToArray()
                .Where(b => b.PublishedOn < date && (int) b.Genre == 3)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new ExportBookXmlDto
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("MM/dd/yyyy")
                })
                .Take(10)
                .ToArray();

            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }
    }
}