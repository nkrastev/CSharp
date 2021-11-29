using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(18,70)]
        public int Age { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
    }
//    •	Id – integer, Primary Key
//•	FirstName– text with min length 3 and max length 20 (required) 
//•	LastName– text with min length 3 and max length 20 (required) 
//•	Age – integer(in range between 18 and 70) (required)
//•	NetWorth – decimal (non-negative, minimum value: 0) (required)
//•	PerformerSongs - collection of type SongPerformer

}
