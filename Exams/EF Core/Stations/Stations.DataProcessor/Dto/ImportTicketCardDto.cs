using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    [XmlType("Card")]
    public class ImportTicketCardDto
    {
        [Required]
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
