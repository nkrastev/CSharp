namespace TeisterMask.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    using System.ComponentModel.DataAnnotations;

    using Shared;

    [XmlType("Task")]
    public class ImportProjectTasksDto
    {
        [Required]
        [MinLength(GlobalConstants.TaskNameMinLength)]
        [MaxLength(GlobalConstants.ProjectNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(0, 4)]
        public int LabelType { get; set; }
    }
}