namespace MUSACA.Data.Models
{
    using System;    
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        [Required]        
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]        
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

    }
}
