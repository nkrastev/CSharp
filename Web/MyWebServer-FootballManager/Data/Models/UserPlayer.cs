namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserPlayer
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public Player Player { get; set; }


    }
}
