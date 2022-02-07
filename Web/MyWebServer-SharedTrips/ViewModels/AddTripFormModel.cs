namespace SharedTrip.ViewModels
{
    using System;

    public class AddTripFormModel
    {
        public string StartPoint { get; init; }
        public string EndPoint { get; init; }
        public DateTime DepartureTime { get; init; }
        public string ImagePath { get; init; }
        public int Seats { get; init; }
        public string Description { get; init; }
    }
}
