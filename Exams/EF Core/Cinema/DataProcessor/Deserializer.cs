using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            List<Movie> validMovies = new List<Movie>();

            StringBuilder sb = new StringBuilder();
            ImportMovieDto[] moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString).ToArray();

            foreach (var movieDto in moviesDto)
            {
                //validate via DTO
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //timespan validation
                TimeSpan timeSpan;
                bool isTimeSpanValid = TimeSpan.TryParseExact(movieDto.Duration, "g", CultureInfo.InvariantCulture, TimeSpanStyles.None, out timeSpan);
                if (!isTimeSpanValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //enum validation
                Genre genre;
                bool isValidEnum = Enum.TryParse(movieDto.Genre, out genre);
                if (!isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //If a title already exists, do not import it and append an error message

                if (context.Movies.Any(x=>x.Title==movieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie validMovie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = timeSpan,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                validMovies.Add(validMovie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, validMovie.Title, validMovie.Genre.ToString(), validMovie.Rating));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            List<Hall> validHalls = new List<Hall>();

            StringBuilder sb = new StringBuilder();
            ImportHallSeatsDto[] hallDtos = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString).ToArray();

            foreach (var hallDto in hallDtos)
            {
                //validate via DTO
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Halls and Seats are valid, generate Hall, generate seats for current hall, save seats, add seats to hall, save hall
                Hall validHall= new Hall{
                    Name=hallDto.Name,
                    Is4Dx=hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                var listOfSeats = new List<Seat>();

                for (int i = 1; i <= hallDto.Seats; i++)
                {
                    Seat validSeat = new Seat
                    {
                        HallId = validHall.Id
                    };
                    listOfSeats.Add(validSeat);
                }

                validHall.Seats = listOfSeats;
                validHalls.Add(validHall);


                var projectionType = GetProjectionString(validHall.Is4Dx, validHall.Is3D);


                sb.AppendLine(String.Format(SuccessfulImportHallSeat, validHall.Name, projectionType, validHall.Seats.Count));
            }
            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportProjectionDto[] projectionDtos = (ImportProjectionDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //check if movie Id exists
                if (!context.Movies.Any(x=>x.Id==projectionDto.MovieId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //check if hall Id exists
                if (!context.Halls.Any(x=>x.Id==projectionDto.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //check if date is valid
                DateTime validDate;
                bool isDateTimeValid = DateTime.TryParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);

                if (!isDateTimeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Projection data is valid, create new one and append it
                Projection validProjection = new Projection
                {
                    MovieId = projectionDto.MovieId,                   
                    HallId = projectionDto.HallId,                    
                    DateTime = validDate
                };                

                context.Projections.Add(validProjection);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportProjection, validProjection.Movie.Title, validProjection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportCustomerDto[] customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);
            List<Customer> validCustomers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer validCustomer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                //validate tickets
                List<Ticket> validTickets = new List<Ticket>();

                foreach (var ticketDto in customerDto.Tickets)
                {
                    //is the projection id valid???

                    if (!IsValid(ticketDto))
                    {                        
                        continue;
                    }

                    Projection projection = context.Projections.FirstOrDefault(x => x.Id == ticketDto.ProjectionId);
                    if (projection == null)
                    {
                        continue;
                    }

                    var validTicket = new Ticket
                    {
                        Price = ticketDto.Price,
                        Projection = projection
                    };
                    validTickets.Add(validTicket);
                }

                validCustomer.Tickets = validTickets;
                validCustomers.Add(validCustomer);
                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, validCustomer.FirstName, validCustomer.LastName, validTickets.Count));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static string GetProjectionString(bool? is4Dx, bool? is3D)
        {
            string projectionType = "Normal";
            if (is4Dx == true && is3D == true)
            {
                projectionType = "4Dx/3D";
            }
            else if (is4Dx == true && is3D == false)
            {
                projectionType = "4Dx";
            }
            else if (is4Dx == false && is3D == true)
            {
                projectionType = "3D";
            }
            return projectionType;
        }
    }
}