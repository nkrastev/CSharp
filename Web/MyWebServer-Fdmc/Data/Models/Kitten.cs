namespace Fdmc.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Kitten
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }
        
        public int Age { get; set; }

        [Required]
        public Breed Breed { get; set; }
    }
}
