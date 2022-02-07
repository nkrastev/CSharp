namespace MUSACA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;    

    public class Receipt
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public DateTime IssuedOn { get; init; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public string UserId { get; set; }
        public User Cashier { get; set; }
    }
}

//•	Has an Id – a GUID String.
//•	Has a Issued On – a DateTime object.
//•	Has a Orders – a collection of Order objects.
//•	Has a Cashier – a User object.
