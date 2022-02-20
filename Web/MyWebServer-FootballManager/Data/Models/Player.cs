namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        [Required]
        public int Id { get; init; } 

        [Required]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Position { get; set; }

        [Range(0,10)]
        [Required]
        public byte Speed { get; set; }

        [Range(0, 10)]
        [Required]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public IEnumerable<UserPlayer> UserPlayers { get; init; } = new List<UserPlayer>();
    }
}
