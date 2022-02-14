namespace IRunes.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Track
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string AlbumId { get; set; }

        public Album Album { get; set; }
    }
}

//•	Id – a string(GuID), Primary key
//•	Name – a string with min length 4 and max length 20 (inclusive) (required)
//•	Link – a string(a link to a video)(required)
//•	Price – a decimal(required)
