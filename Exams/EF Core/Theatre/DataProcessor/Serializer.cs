namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {

            var theatres = context
                .Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                //TotalIncome of tickets which are between the first and fifth row inclusively, and Tickets
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(ti=>ti.RowNumber>=1 && ti.RowNumber<=5).Sum(pr=>pr.Price),
                    Tickets = x.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                    .Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })                   
                    .OrderByDescending(t => t.Price)
                    .ToArray()

                })               
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToArray();

            var output = JsonConvert.SerializeObject(theatres, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
                //NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .ToArray()
                .Where(x=>x.Rating<=rating)                
                .Select(x=> new ExportPlayDto()
                {
                    Title=x.Title,
                    Duration=x.Duration.ToString("c"),
                    Rating=x.Rating==0 ? "Premier" : x.Rating.ToString(),
                    Genre=x.Genre.ToString(),
                    Actors=x.Casts
                        .ToArray()
                        .Where(a=>a.IsMainCharacter)
                        .Select(a=>new ExportActorDto
                        {
                            FullName=a.FullName,
                            MainCharacter=$"Plays main character in '{x.Title}'."
                        })
                        .OrderByDescending(a=>a.FullName)
                        .ToArray()
                })
                .OrderBy(x=>x.Title)
                .ThenByDescending(x=>x.Genre)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(ExportPlayDto[]), new XmlRootAttribute("Plays"));
            xml.Serialize(new StringWriter(sb), plays, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}
