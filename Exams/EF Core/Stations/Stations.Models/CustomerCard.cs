using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class CustomerCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [Range(0,120)] //check if range is validated in EF Core
        public int Age { get; set; }

        [DefaultValue(CardType.Normal)]
        public CardType Type { get; set; }

        public virtual ICollection<Ticket> BoughtTickets { get; set; } = new HashSet<Ticket>();
    }

//    •	Id – integer, Primary Key
//•	Name – text with max length 128 (required)
//•	Age – integer between 0 and 120
//•	Type – CardType enumeration with values: "Pupil", "Student", "Elder", "Debilitated", "Normal" (default: Normal)
//•	BoughtTickets – Collection of type Ticket

}