using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression(@"^([A-Z]{1}[a-z]{1,}) ([A-Z]{1}[a-z]{1,})$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        [Required]
        public List<ImportCardDto> Cards { get; set; }
    }
}
