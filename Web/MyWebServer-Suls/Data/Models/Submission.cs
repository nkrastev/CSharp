namespace Suls.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(30)]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]
        [Range(0,300)]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string ProblemId { get; set; }

        public Problem Problem { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
