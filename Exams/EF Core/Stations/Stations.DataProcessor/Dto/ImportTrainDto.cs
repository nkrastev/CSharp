using Stations.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class ImportTrainDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        [Range(0, 2)]
        public TrainType? Type { get; set; }
        public ImportSeatDto[] Seats { get; set; }
    }

}
