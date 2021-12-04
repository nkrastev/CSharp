using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportProjectionDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        public ImportTicketDto[] Tickets { get; set; }
    }
}

//"Name": "",
//    "NumberOfHalls": 7,
//    "Director": "Ulwin Mabosty",
//    "Tickets": [
//      {
//        "Price": 7.63,
//        "RowNumber": 5,
//        "PlayId": 4
//      },
//      {
//    "Price": 47.96,
//        "RowNumber": 9,
//        "PlayId": 3
//      }

