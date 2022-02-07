namespace MUSACA.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public long Barcode { get; set; }

        public string Picture { get; set; }
    }
}
