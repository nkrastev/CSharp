﻿namespace IRunes.ViewModels.Albums
{
    using IRunes.Data.Models;
    using System.Collections.Generic;

    public class AlbumViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public string Price { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
