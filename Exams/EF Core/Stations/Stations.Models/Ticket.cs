using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(8)]
        public string SeatingPlace { get; set; }

        [Required]
        public int TripId { get; set; }

        [Required]
        public Trip Trip { get; set; }

        public int? CustomerCardId { get; set; }

        public CustomerCard CustomerCard { get; set; }

    }
  
//Id – integer, Primary Key
//•	Price – decimal value of the ticket(required, non-negative)
//•	SeatingPlace – text with max length of 8 which combines seating class abbreviation plus a positive integer(required)
//•	TripId – integer(required)
//•	Trip – the trip for which the ticket is for (required)
//•	CustomerCardId – integer(optional)
//•	CustomerCard – reference to the ticket’s buyer

}
