using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class ImportClassDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string Abbreviation { get; set; }
    }
}

//{
//    "Name": "First class",
//    "Abbreviation": "FC"
//  }
