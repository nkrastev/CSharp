using Newtonsoft.Json;
using Stations.Data;
using Stations.Models;
using System;
using System.Globalization;
using System.Linq;

namespace Stations.DataProcessor
{
    public class Serializer
    {
        public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
        {
            var trains = context
                .Trains
                .Where(t => t.Trips.Any(tr =>
                    tr.Status == TripStatus.Delayed && tr.DepartureTime <=
                    DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .Select(t => new
                {
                    TrainNumber = t.TrainNumber,
                    DelayedTimes = t.Trips.Count(tr =>
                        tr.Status == TripStatus.Delayed && tr.DepartureTime <=
                        DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture)),
                    MaxDelayedTime = t.Trips.Max(tr => tr.TimeDifference)
                })
                .OrderByDescending(t => t.DelayedTimes)
                .ThenByDescending(t => t.MaxDelayedTime)
                .ThenBy(t => t.TrainNumber)
                .ToList();

            var output = JsonConvert.SerializeObject(trains, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                //NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportCardsTicket(StationsDbContext context, string cardType)
        {
            return "Todo";
        }
    }
}