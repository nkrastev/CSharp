namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors                
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                            .OrderByDescending(y => y.Book.Price)
                            .Select(b => new
                            {
                                BookName = b.Book.Name,
                                BookPrice = b.Book.Price.ToString("f2")
                            })
                            .ToList()
                })
                .ToList()
                .OrderByDescending(b => b.Books.Count())
                .ThenBy(a => a.AuthorName);
                            
            
            var output = JsonConvert.SerializeObject(authors, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
                //NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context
                .Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(x=>x.Pages)
                .ThenByDescending(x=>x.PublishedOn)
                .Select(x => new ExportOldestBooksDto()
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })                
                .Take(10)
                .ToArray();


            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(ExportOldestBooksDto[]), new XmlRootAttribute("Books"));
            xml.Serialize(new StringWriter(sb), books, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}