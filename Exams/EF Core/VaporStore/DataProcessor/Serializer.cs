namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;    

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{			
			var gamesWithGenre = context
				.Genres
				.ToArray()
				.Where(x=>genreNames.Contains(x.Name) && x.Games.Count>0)
				.Select(x=> new
                {
					Id=x.Id,
					Genre=x.Name,
					Games=x.Games.Where(plCount=>plCount.Purchases.Count>0).
						Select(g=> new
						{
							Id=g.Id,
							Title=g.Name,
							Developer=g.Developer.Name,
							Tags=String.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
							Players=g.Purchases.Count()
						})
						.OrderByDescending(p=>p.Players)
						.ThenBy(g=>g.Id)
						.ToList(),
					TotalPlayers=x.Games.Sum(pur=>pur.Purchases.Count)
				})
				.ToList()
				.OrderByDescending(p=>p.Games.Sum(pl=>pl.Players))
				.ThenBy(i=>i.Id)
				.ToList();			

			var output = JsonConvert.SerializeObject(gamesWithGenre, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});

			return output;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			// you can go via context as many time as you want!!!

			var users = context
				.Users
				.ToArray()
				.Where(u => u.Cards.Any(c => c.Purchases.Any()))
				.Select(u => new ExportUserPurchasesByTypeDto()
				{
					Username = u.Username,
					Purchases = context.Purchases
						.ToArray()
						.Where(p => p.Card.User.Username == u.Username && p.Type.ToString() == storeType)
						.OrderBy(p => p.Date)
						.Select(p => new ExportPurchaseDto()
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new ExportGameDto()
							{
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price
							}
						})
						.ToArray(),
					TotalSpent = context
						.Purchases
						.ToArray()
						.Where(p => p.Card.User.Username == u.Username && p.Type.ToString() == storeType)
						.Sum(p => p.Game.Price)

				})
				.Where(u => u.Purchases.Length > 0)
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();



			StringBuilder sb = new StringBuilder();
			var namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			XmlSerializer xml = new XmlSerializer(typeof(ExportUserPurchasesByTypeDto[]), new XmlRootAttribute("Users"));
			xml.Serialize(new StringWriter(sb), users, namespaces);
			return sb.ToString().Trim();
		}
	}
}