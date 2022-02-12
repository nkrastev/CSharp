namespace Panda.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        [Required]        
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }       

        [Required]        
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Package> Packages { get; set; } = new HashSet<Package>();

        public ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
