namespace Andreys.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}

