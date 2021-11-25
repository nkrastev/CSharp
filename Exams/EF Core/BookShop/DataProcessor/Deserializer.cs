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
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfullyImportedBook= "Successfully imported book {0} for {1:F2}.";
        private const string SuccessfullyImportedAuthor= "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportBookDto[] bookDtos = (ImportBookDto[])xmlSerializer.Deserialize(stringReader);

            List<Book> validBooks = new List<Book>();

            foreach (var bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //date validation
                DateTime validDate;
                bool isOpenDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                /*//enum validation
                Genre genre;
                bool isValidGenreType = Enum.TryParse(bookDto.Genre, out genre);
                if (!isValidGenreType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }*/

                //all fields are valid, create book and add it to valid ones

                var validBook= new Book(){
                    Name=bookDto.Name,
                    Genre=(Genre)bookDto.Genre,
                    Price=bookDto.Price,
                    Pages=bookDto.Pages,
                    PublishedOn=validDate
                };
                validBooks.Add(validBook);
                sb.AppendLine(string.Format(SuccessfullyImportedBook,validBook.Name, validBook.Price));
            }

            //save range to DB
            context.Books.AddRange(validBooks);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            List<Author> validAuthors = new List<Author>();
            List<Book> allBooks = context.Books.ToList();
            
            StringBuilder sb = new StringBuilder();

            ImportAuthorDto[] authorsDto = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString).ToArray();

            foreach (var authorDto in authorsDto)
            {
                //first name, last name, email or phone
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //If an email exists, do not import the author and append and error message
                if (context.Authors.Any(x=>x.Email==authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email
                };

                foreach (var bookItemDto in authorDto.Books)
                {
                    if (!bookItemDto.Id.HasValue)
                    {
                        continue;
                    }

                    Book book = context.Books.FirstOrDefault(x => x.Id == bookItemDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        Book = book,
                        Author = author
                    });
                }

                if (!author.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validAuthors.Add(author);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
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