using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor
{
    public class ImportAuthorDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ImportBookIdDto[] Books { get; set; }
    }

  //  {
  //  "FirstName": "Maridel",
  //  "LastName": "N",
  //  "Phone": "658-437-4751",
  //  "Email": "mdeamaya1@theatlantic.com",
  //  "Books": [
  //    {
  //      "Id": 117
  //    },
  //    {
  //  "Id": 88
  //    }
  //  ]
  //},
}