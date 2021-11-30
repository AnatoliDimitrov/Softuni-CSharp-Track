using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var result = new StringBuilder();

            using StringReader reader = new StringReader(xmlString);

            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookXmlDto[]), root);

            var dtos = (ImportBookXmlDto[])serializer.Deserialize(reader);

            foreach (var dto in dtos)
            {
                var isValidDate = DateTime.TryParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                var isValidGenre = dto.Genre > 0 && dto.Genre <= 3;

                if (!IsValid(dto) || !isValidDate || !isValidGenre)
                {
                    result.AppendLine("Invalid data!");
                    continue;
                }

                var book = new Book()
                {
                   Name = dto.Name,
                   Genre = (Genre)dto.Genre,
                   Price = decimal.Parse(dto.Price.ToString("f2")),
                   Pages = dto.Pages,
                   PublishedOn = date,
                };

                result.AppendLine($"Successfully imported book {book.Name} for {book.Price}.");
                context.Books.Add(book);
                context.SaveChanges();
            }

            return result.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var result = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<ImportAuthorJsonDto>>(jsonString).ToList();

            foreach (var dto in dtos)
            {

                var mail = context.Authors.FirstOrDefault(a => a.Email == dto.Email);

                if (!IsValid(dto) || mail != null)
                {
                    result.AppendLine("Invalid data!");
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    Email = dto.Email,
                };

                foreach (var dtoBook in dto.Books)
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == dtoBook.Id);

                    if (dtoBook.Id == null || book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook(){BookId = dtoBook.Id.Value, Author = author});
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    result.AppendLine("Invalid data!");
                    continue;
                }

                result.AppendLine(
                    $"Successfully imported author - {author.FirstName + " " + author.LastName} with {author.AuthorsBooks.Count} books.");
                context.Authors.Add(author);
                context.SaveChanges();
            }

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}