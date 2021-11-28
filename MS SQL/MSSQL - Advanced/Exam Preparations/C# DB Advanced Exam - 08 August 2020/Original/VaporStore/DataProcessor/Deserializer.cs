using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<ImportGameJsonDto>>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Tags == null || dto.Tags.Length == 0)
                {
                    result.AppendLine("Invalid Data");
					continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == dto.Developer)
                                ?? new Developer() { Name = dto.Developer };

				var genre = context.Genres.FirstOrDefault(g => g.Name == dto.Genre)
                            ?? new Genre() { Name = dto.Genre };

                var game = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = dto.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tagDto in dto.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == tagDto)
                              ?? new Tag() { Name = tagDto};

                    game.GameTags.Add(new GameTag(){ Tag = tag });
                }

                result.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");

                context.Games.Add(game);
                context.SaveChanges();
            }

            return result.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var result = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<ImportUserJsonDto>>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !dto.Cards.All(IsValid))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    Username = dto.Username,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Age = dto.Age,
                };

                foreach (var cardDto in dto.Cards)
                {
                    var card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardDto.Type.Value,
                    };

                    user.Cards.Add(card);
                }

                context.Users.Add(user);
                context.SaveChanges();

                result.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            return result.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var result = new StringBuilder();

            using StringReader reader = new StringReader(xmlString);

            XmlRootAttribute root = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseXmlDto[]), root);

            var dtos = (ImportPurchaseXmlDto[])serializer.Deserialize(reader);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(g => g.Name == dto.Title);
                var card = context.Cards.FirstOrDefault(c => c.Number == dto.Card);
                var isRealDate = DateTime.TryParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                if (game == null || card == null || !isRealDate)
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase()
                {
                    Type = dto.Type.Value,
                    ProductKey = dto.Key,
                    Date = date,
                    Card = card,
                    Game = game,
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                result.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
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