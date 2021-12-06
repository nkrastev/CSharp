using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class SeatingClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string Abbreviation { get; set; }
    }

//    •	Id – integer, Primary Key
//•	Name – text with max length 30 (required, unique)
//•	Abbreviation – text with an exact length of 2 (no more, no less), (required, unique)

}
