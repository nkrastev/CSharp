namespace TeisterMask.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    using System.ComponentModel.DataAnnotations;

    using Shared;

    [XmlType("Project")]
    public class ImportProjectDto
    {
        [Required]
        [MinLength(GlobalConstants.ProjectNameMinLength)]
        [MaxLength(GlobalConstants.ProjectNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportProjectTasksDto[] Tasks { get; set; }
    }
}