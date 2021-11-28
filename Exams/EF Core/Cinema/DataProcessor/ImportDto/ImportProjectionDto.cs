using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
    public class ImportProjectionDto
    {        
        [XmlElement("MovieId")]
        [Required]
        public int MovieId { get; set; }

      
        [XmlElement("HallId")]
        [Required]
        public int HallId { get; set; }

        //validation in Deserializer
        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }       

    }
}
