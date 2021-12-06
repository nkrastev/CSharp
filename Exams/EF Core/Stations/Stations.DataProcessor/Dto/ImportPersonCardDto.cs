using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    [XmlType("Card")]
    public class ImportPersonCardDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        public string CardType { get; set; }
    }
}
