namespace VaporStore.DataProcessor
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
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{           
            List<Game> validGames = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();

			StringBuilder sb = new StringBuilder();

			ImportGameDto[] games = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString).ToArray();



            foreach (var game in games)
            {
                //validate via DTO
                if (!IsValid(game))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //date validation
                DateTime releaseDate;
                bool isDateValid = DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);
                if (!isDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //tags exists
                if (game.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game gametoAdd = new Game()
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = releaseDate
                };

                //developers check
                var dev = developers.FirstOrDefault(d => d.Name == game.Developer);
                if (dev == null)
                {
                    dev = new Developer()
                    {
                        Name = game.Developer
                    };
                    developers.Add(dev);
                }

                gametoAdd.Developer = dev;

                //genre check
                var genre = genres.FirstOrDefault(g => g.Name == game.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = game.Genre
                    };
                    genres.Add(genre);
                }

                gametoAdd.Genre = genre;

                //tags check
                foreach (var tagItem in game.Tags)
                {
                    if (String.IsNullOrEmpty(tagItem))
                    {
                        continue;
                    }

                    Tag tag = tags.FirstOrDefault(x => x.Name == tagItem);
                    if (tag == null)
                    {
                        Tag t = new Tag()
                        {
                            Name = tagItem
                        };
                        tags.Add(t);

                        gametoAdd.GameTags.Add(new GameTag()
                        {
                            Game = gametoAdd,
                            Tag = t
                        });
                    }
                    else
                    {
                        gametoAdd.GameTags.Add(new GameTag()
                        {
                            Game = gametoAdd,
                            Tag = tag
                        });
                    }

                }

                if (!gametoAdd.GameTags.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                validGames.Add(gametoAdd);
                sb.AppendLine($"Added {gametoAdd.Name} ({gametoAdd.Genre.Name}) with {gametoAdd.GameTags.Count} tags");
            }

            context.Games.AddRange(validGames);
            context.Genres.AddRange(genres);
            context.Developers.AddRange(developers);
            context.Tags.AddRange(tags);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            List<User> validUsers = new List<User>();
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] users = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString).ToArray();

            foreach (var user in users)
            {
                //validate via DTO
                if (!IsValid(user))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (user.Cards.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                User userToBeAdded = new User()
                {
                    FullName=user.FullName,
                    Username=user.Username,
                    Email=user.Email,
                    Age=user.Age                    
                };

                foreach (var cardDto in user.Cards)
                {
                    //validate via DTO
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine("Invalid Data");
                        break;
                    }

                    //Enum validation
                    CardType type;
                    bool isValidCardType = Enum.TryParse(cardDto.Type, out type);
                    if (!isValidCardType)
                    {
                        sb.AppendLine("Invalid Data");
                        break;
                    }

                    Card card = new Card()
                    {
                        Cvc = cardDto.Cvc, //validated via dto
                        Number = cardDto.Number, //validated via dto
                        Type = type,                        
                    };

                    //current card is valid, append it to user which is going to be added               
                    userToBeAdded.Cards.Add(card);
                    
                }

                //current user is valid, cards are validated and added, append the user to the valid users
                validUsers.Add(userToBeAdded);

                sb.AppendLine($"Imported {userToBeAdded.Username} with {userToBeAdded.Cards.Count} cards");

            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();            
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportPurchaseDto[] purchaseDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(stringReader);

            List<Purchase> purchasesToBeAdded = new List<Purchase>();

            //!!! Type is ENUM, validate it!!!, 

            foreach (var purchaseItem in purchaseDto)
            {
                //validation of title, key and card
                if (!IsValid(purchaseItem))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //date validation
                DateTime validDate;
                bool isOpenDateValid = DateTime.TryParseExact(purchaseItem.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //enum validation, purchaseType
                PurchaseType type;
                bool isValidPurchaseType = Enum.TryParse(purchaseItem.Type, out type);
                if (!isValidPurchaseType)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //All fields are valid, get card and game

                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseItem.Card);
                if (card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseItem.Title);
                if (game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //fields are valid, card and game also, append record

                Purchase validPurchase = new Purchase()
                {
                    Type = type,
                    ProductKey = purchaseItem.Key,
                    Card = card,
                    Date = validDate,
                    Game = game
                };

                purchasesToBeAdded.Add(validPurchase);
                sb.AppendLine($"Imported {validPurchase.Game.Name} for {validPurchase.Card.User.Username}");

            }

            context.Purchases.AddRange(purchasesToBeAdded);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();
			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}