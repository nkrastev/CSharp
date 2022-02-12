namespace Andreys.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        [Required]        
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Username { get; set; }       

        [Required]        
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
