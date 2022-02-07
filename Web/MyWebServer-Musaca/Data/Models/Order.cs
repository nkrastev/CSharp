namespace MUSACA.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public Status Status { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string UserId { get; set; }
        public User Cashier { get; set; }
    }
}