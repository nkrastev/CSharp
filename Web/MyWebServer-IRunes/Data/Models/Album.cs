namespace IRunes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Track> Tracks = new HashSet<Track>();
    }
}

//•	Name – a string with min length 4 and max length 20 (inclusive) (required)
//•	Cover – a string(a link to an image)(required)
//•	Price – a decimal(sum of all Tracks’ prices, reduced by 13 %)(required)
//•	Tracks – a collection of Tracks

