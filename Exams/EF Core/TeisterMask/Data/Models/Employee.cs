using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        //public int TaskId { get; set; }
        public ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
