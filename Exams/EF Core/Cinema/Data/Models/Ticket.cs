using Cinema.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }


        //•	Id – integer, Primary Key
        //•	Price – decimal (non-negative, minimum value: 0.01) (required)
        //•	CustomerId – integer, foreign key(required)
        //•	Customer – the customer’s ticket 
        //•	ProjectionId – integer, foreign key(required)
        //•	Projection – the projection’s ticket

    }
}