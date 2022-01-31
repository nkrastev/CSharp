namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        [Required]        
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]        
        public string Password { get; set; }

        [Required]
        public string CartId { get; init; }

        [Required]
        public Cart Cart { get; set; }
    }
}
