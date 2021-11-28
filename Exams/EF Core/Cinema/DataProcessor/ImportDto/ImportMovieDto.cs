using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor
{
    public class ImportMovieDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        //validation in Dto
        [Required]
        public string Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Director { get; set; }

        //      {
        //  "Title": "Little Big Man",
        //  "Genre": "Western",
        //  "Duration": "01:58:00",
        //  "Rating": 28,
        //  "Director": "Duffie Abrahamson"
        //}

    }
}