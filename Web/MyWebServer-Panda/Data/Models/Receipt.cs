namespace Panda.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Receipt
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        [Required]
        public string PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}