namespace SharedTrip.ViewModels
{
    using System;

    public class TripDetailsViewModel
    {
        public string Id { get; init; }

        public string Start { get; init; }

        public string End { get; init; }

        public string DepartureTime { get; init; }

        public int Seats { get; init; }
        public string Description { get; init; }

        public string ImagePath { get; set; }
    }
}
