namespace Panda.Data.Models
{
    using Panda.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        [Required]
        public Status Status { get; set; }

        // Unknown field :)
        public DateTime? EstimatedDeliveryDate { get; set; }

        public User Recipient { get; set; }

        [Required]
        public string RecipientId { get; set; }


    }
}

