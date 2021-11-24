using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required] //validations in DTO
        public string Phone { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; } = new HashSet<AuthorBook>();


    }

  /*  •	Id - integer, Primary Key
•	FirstName - text with length[3, 30]. (required)
•	LastName - text with length[3, 30]. (required)
•	Email - text(required). Validate it! There is attribute for this job.
•	Phone - text.Consists only of three groups (separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
•	AuthorsBooks - collection of type AuthorBook
  */
    }
