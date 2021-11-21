using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        public Cell()
        {
            this.Prisoners = new HashSet<Prisoner>();
        }

        [Key]
        public int Id { get; set; }
        
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
          
        public int DepartmentId { get; set; }

        
        public Department Department { get; set; }

        public ICollection<Prisoner> Prisoners { get; set; }

    }
}