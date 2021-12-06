using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto;
using Stations.Models;
using Stations.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";

        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            //            •	If the town name is not given, insert it with the same value as the station name.
            //•	If a station with the same name already exists, ignore the entity.
            //•	If any other validation error occurs(such as long station or town name) proceed as described above.

            List<Station> validStations = new List<Station>();
            StringBuilder sb = new StringBuilder();
            ImportStationDto[] stationDtos = JsonConvert.DeserializeObject<ImportStationDto[]>(jsonString).ToArray();

            foreach (var stationDto in stationDtos)
            {
                if (!IsValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Station station = new Station
                {
                    Name = stationDto.Name,  
                    Town= stationDto.Town
                };

                //uniqueness is checked in Fluent API... nope

                if (validStations.Any(x=>x.Name==stationDto.Name))
                {
                    sb.AppendLine(FailureMessage+" -------------------> dublicated Station Name");
                    continue;
                }


                if (stationDto.Town=="" || stationDto.Town==null)
                {
                    station.Town = station.Name;
                }
                else
                {
                    station.Town = stationDto.Town;                    
                }
                validStations.Add(station);
                sb.AppendLine(String.Format(SuccessMessage, station.Name));
            }

            context.Stations.AddRange(validStations);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            //If a seating class with the same name or abbreviation already exists, ignore the entity.
            //If any validation error occurs(such as long name or incorrect abbreviation length), proceed as described above.

            List<SeatingClass> validClasses = new List<SeatingClass>();
            StringBuilder sb = new StringBuilder();
            ImportClassDto[] seatingClassesDtos = JsonConvert.DeserializeObject<ImportClassDto[]>(jsonString).ToArray();

            foreach (var seatClassDto in seatingClassesDtos)
            {
                if (!IsValid(seatClassDto))
                {
                    sb.AppendLine(FailureMessage+" Seating classes DTO validation");
                    continue;
                }

                SeatingClass seating = new SeatingClass
                {
                    Name = seatClassDto.Name,
                    Abbreviation = seatClassDto.Abbreviation
                };

                if (validClasses.Any(x=>x.Name==seatClassDto.Name || x.Abbreviation==seatClassDto.Abbreviation))
                {
                    sb.AppendLine(FailureMessage + " Some of the fields is not unique.");
                    continue;
                }                

                validClasses.Add(seating);
                sb.AppendLine(String.Format(SuccessMessage, seating.Name));
            }

            context.SeatingClasses.AddRange(validClasses);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            List<Train> validTrains = new List<Train>();
            StringBuilder sb = new StringBuilder();
            ImportTrainDto[] trainDtos = JsonConvert.DeserializeObject<ImportTrainDto[]>(jsonString).ToArray();

            foreach (var trainDto in trainDtos)
            {

                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage + " Train DTO validation");
                    continue;
                }

                if (trainDto.Seats == null || !trainDto.Seats.All(IsValid))
                {
                    sb.AppendLine(FailureMessage + " Seat DTO validation");
                    continue;
                }                

                //Existing train 
                if (validTrains.Any(t => t.TrainNumber == trainDto.TrainNumber))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                if (trainDto.Type == null)
                {
                    trainDto.Type = TrainType.HighSpeed;
                }

                if (!trainDto.Seats
                       .All(s => context.SeatingClasses
                                      .Any(sc => sc.Name == s.Name &&
                                                 sc.Abbreviation == s.Abbreviation)))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                var trainSeats = trainDto.Seats
                    .Select(s => new TrainSeat()
                    {
                        SeatingClass = context.SeatingClasses.FirstOrDefault(sc =>
                            sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                        Quantity = s.Quantity.Value
                    })
                    .ToList();

                var train = new Train()
                {
                    TrainNumber = trainDto.TrainNumber,
                    TrainType = trainDto.Type,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);
                sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var serializer = JsonConvert.DeserializeObject<List<ImportTripDto>>(jsonString);

            var tripsToAdd = new List<Trip>();

            foreach (var tripDto in serializer)
            {
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                if (tripDto.Status == null)
                {
                    tripDto.Status = TripStatus.OnTime;
                }

                var train = context.Trains.FirstOrDefault(t => t.TrainNumber == tripDto.Train);

                var originStation = context.Stations.FirstOrDefault(s => s.Name == tripDto.OriginStation);

                var destinationStation = context.Stations.FirstOrDefault(s => s.Name == tripDto.DestinationStation);

                if (train == null ||
                    originStation == null ||
                    destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                DateTime departureDate;

                var isDepartureDateValid = DateTime.TryParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out departureDate);

                DateTime arrivalDate;

                var isArrivalDateValid = DateTime.TryParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out arrivalDate);

                TimeSpan timeDifference=new TimeSpan();

                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture, TimeSpanStyles.None);
                }

                if (!isDepartureDateValid ||
                    !isArrivalDateValid ||
                    (arrivalDate <= departureDate))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                var trip = new Trip()
                {
                    ArrivalTime = arrivalDate,
                    DepartureTime = departureDate,
                    DestinationStation = destinationStation,
                    OriginStation = originStation,
                    Status = tripDto.Status.Value,
                    TimeDifference = timeDifference,
                    Train = train
                };

                tripsToAdd.Add(trip);

                sb.AppendLine($"Trip from {originStation.Name} to {destinationStation.Name} imported.");
            }

            context.Trips.AddRange(tripsToAdd);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ImportPersonCardDto>), new XmlRootAttribute("Cards"));

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            var reader = new StringReader(xmlString);

            var personCardsToAdd = new List<CustomerCard>();

            using (reader)
            {
                var customerCardDtos = (List<ImportPersonCardDto>)serializer.Deserialize(reader);

                foreach (var customerCardDto in customerCardDtos)
                {
                    if (!IsValid(customerCardDto))
                    {
                        sb.AppendLine(FailureMessage);

                        continue;
                    }

                    var cardType = Enum.TryParse<CardType>(customerCardDto.CardType, out var card) ? card : CardType.Normal;

                    var customerCard = new CustomerCard()
                    {
                        Name = customerCardDto.Name,
                        Type = cardType,
                        Age = customerCardDto.Age
                    };

                    personCardsToAdd.Add(customerCard);

                    sb.AppendLine(string.Format(SuccessMessage, customerCard.Name));
                }

                context.CustomerCards.AddRange(personCardsToAdd);

                context.SaveChanges();

                return sb.ToString().Trim();
            }
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(List<ImportTicketDto>), new XmlRootAttribute("Tickets"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var reader = new StringReader(xmlString);
            var ticketsToAdd = new List<Ticket>();

            using (reader)
            {
                var ticketDtos = (List<ImportTicketDto>)serializer.Deserialize(reader);

                foreach (var ticketDto in ticketDtos)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(FailureMessage);

                        continue;
                    }

                    var departureDate = DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    var trip = context.Trips.FirstOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation && t.DepartureTime == departureDate && t.DestinationStation.Name == ticketDto.Trip.DestinationStation);

                    if (trip == null)
                    {
                        sb.AppendLine(FailureMessage);

                        continue;
                    }

                    CustomerCard card = null;

                    if (ticketDto.Card != null)
                    {
                        card = context.CustomerCards
                            .FirstOrDefault(c => c.Name == ticketDto.Card.Name);

                        if (card == null)
                        {
                            sb.AppendLine(FailureMessage);

                            continue;
                        }
                    }

                    var seatinClassAbbreviation = ticketDto.Seat
                        .Substring(0, 2);

                    var quantity = int.Parse(ticketDto.Seat.Substring(2));

                    var seat = trip.Train
                        .TrainSeats
                        .FirstOrDefault(ts => ts.SeatingClass.Abbreviation == seatinClassAbbreviation &&
                                              quantity <= ts.Quantity);

                    if (seat == null)
                    {
                        sb.AppendLine(FailureMessage);

                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Trip = trip,
                        CustomerCard = card,
                        Price = ticketDto.Price,
                        SeatingPlace = ticketDto.Seat
                    };

                    ticketsToAdd.Add(ticket);

                    sb.AppendLine($"Ticket from {trip.OriginStation.Name} to {trip.DestinationStation.Name} departing at {departureDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} imported.");
                }

                context.Tickets.AddRange(ticketsToAdd);

                context.SaveChanges();

                return sb.ToString().Trim();
            }
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}