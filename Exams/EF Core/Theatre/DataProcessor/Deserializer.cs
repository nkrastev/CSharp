namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), new XmlRootAttribute("Plays"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(stringReader);

            List<Play> validPlays = new List<Play>();

            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //timespan validation
                TimeSpan timeSpan;
                bool isTimeSpanValid = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out timeSpan);
                
                if (!isTimeSpanValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (timeSpan.TotalSeconds<3600)
                {
                    //•	Duration of the play is less than 1(one) hour                    
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //enum validation
                Genre genre;
                bool isValidEnum = Enum.TryParse(playDto.Genre, out genre);
                if (!isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play
                {
                    Title = playDto.Title,
                    Duration = timeSpan,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter=playDto.Screenwriter
                };

                validPlays.Add(play);
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), new XmlRootAttribute("Casts"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(stringReader);

            List<Cast> validCasts = new List<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //invalid play id?
                var play = context.Plays.FirstOrDefault(h => h.Id == castDto.PlayId);                

                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    Play = play
                };
               
                //Successfully imported actor {fullName} as a {main/lesser} character!
                string isMain = "main";
                if (cast.IsMainCharacter==false)
                {
                    isMain = "lesser";
                }

                validCasts.Add(cast);
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, isMain));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportProjectionDto[] projectionDtos = JsonConvert.DeserializeObject<ImportProjectionDto[]>(jsonString).ToArray();

            List<Theatre> validTheatres = new List<Theatre>();

            foreach (var projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre
                {
                    Name = projectionDto.Name,
                    NumberOfHalls = projectionDto.NumberOfHalls,
                    Director = projectionDto.Director
                };

                List<Ticket> tickets = new List<Ticket>();
                bool areTicketsValid = true;

                foreach (var ticketDto in projectionDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    //check the play ID
                    /*var play = context.Plays.FirstOrDefault(h => h.Id == ticketDto.PlayId);
                    if (play == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        areTicketsValid = false;
                        break;
                    }*/

                    Ticket validTicket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    tickets.Add(validTicket);
                }

                if (!areTicketsValid)
                {
                    continue;
                }

                theatre.Tickets = tickets;

                validTheatres.Add(theatre);
                //Successfully imported theatre {theatreName} with #{totalNumber} tickets!
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
