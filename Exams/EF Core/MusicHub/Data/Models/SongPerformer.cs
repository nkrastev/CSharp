using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [Required]
        public int SongId { get; set; }

        public Song Song { get; set; }

        [Required]
        public int PerformerId { get; set; }

        public Performer Performer { get; set; }
    }

//    •	SongId – integer, Primary Key
//•	Song – the performer’s song(required)
//•	PerformerId – integer, Primary Key
//•	Performer – the song’s performer(required)

}