namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();


        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        
        public string CartId { get; init; }

        public Cart Cart { get; set; }
    }
}
