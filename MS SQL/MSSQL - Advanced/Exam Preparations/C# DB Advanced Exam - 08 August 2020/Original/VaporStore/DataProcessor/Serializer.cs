using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where( ga => ga.Purchases.Any())
                        .Select(ga => new
                        {
                            Id = ga.Id,
                            Title = ga.Name,
                            Developer = ga.Developer.Name,
                            Tags = string.Join(", ", ga.GameTags
                                .Select(gt => gt.Tag.Name)
                                .ToArray()),
                            Players = ga.Purchases.Count,
                        })
                        .OrderByDescending(ga => ga.Players)
                        .ThenBy(ga => ga.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.SelectMany(ga => ga.Purchases).Count(),
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            return JsonConvert.SerializeObject(genres, Formatting.Indented).TrimEnd();
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserXmlDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Users
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new ExportUserXmlDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Select(p => new ExportPurchaseXmlDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameXmlDto
                            {
                                Title = p.Game.Name,
                                Price = p.Game.Price,
                                Genre = p.Game.Genre.Name,
                            }
                        })
                        .OrderBy(x => x.Date)
                        .ToArray(),
                    TotalSpent = u.Cards.Sum( c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price)),
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();


            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }
	}
}