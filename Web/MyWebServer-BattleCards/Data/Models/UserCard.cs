namespace BattleCards.Models
{
    using BattleCards.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserCard
    {
        [Required]
        public string UserId { get; init; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        [Required]
        public int CardId { get; set; }

        public Card Card { get; set; }
    }
}
