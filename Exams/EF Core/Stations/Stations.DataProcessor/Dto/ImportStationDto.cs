﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.DataProcessor
{
    public class ImportStationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Town { get; set; }
    }

  //  {
  //  "Name": "Sofia Sever",
  //  "Town": "Sofia"
  //},
}
