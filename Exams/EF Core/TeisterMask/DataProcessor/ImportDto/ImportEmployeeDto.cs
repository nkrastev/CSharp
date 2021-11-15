namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Shared;

    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(GlobalConstants.EmployeeUsernameMinLength)]
        [MaxLength(GlobalConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(GlobalConstants.EmployeeUsernameRegex)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.EmployeePhoneRegex)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
