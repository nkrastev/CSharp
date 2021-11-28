using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;
    using Cinema.DataProcessor.ExportDto;
    using Data;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Count > 0))  
                .ToArray()
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(pr => pr.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(pr=>pr.Price)).ToString("f2"),
                    Customers= x.Projections.SelectMany(p => p.Tickets
                            .Select(t => new
                            {
                                FirstName = t.Customer.FirstName,
                                LastName = t.Customer.LastName,
                                Balance = t.Customer.Balance.ToString("f2")
                            })
                        .ToList())
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToList()
                })                                
                .Take(10) 
                /*.OrderByDescending(x=>x.Rating)
                .ThenByDescending(x=>x.TotalIncomes)*/
                .ToList();


            var output = JsonConvert.SerializeObject(movies, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
                //NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .ToArray()
                .Where(x => x.Age >= age)
                .OrderByDescending(x=>x.Tickets.Sum(t => t.Price))
                .Select(x => new ExportCustomerDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = Math.Round(x.Tickets.Sum(t => t.Price), 2, MidpointRounding.AwayFromZero),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(z => z.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();
                
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));
            xml.Serialize(new StringWriter(sb), customers, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}