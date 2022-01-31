namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();


        [Required]
        public User User { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
