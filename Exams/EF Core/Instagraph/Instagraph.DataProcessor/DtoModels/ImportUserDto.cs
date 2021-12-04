using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Instagraph.DataProcessor.DtoModels
{
    public class ImportUserDto
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string ProfilePicture { get; set; }
    }

    //A user must have a valid profile picture, username and password.
    //  "Username" : "BlaSinduxrein", a string with max length 30, Unique
    //"Password" : "wJyfcwg*", a string with max length 20
    //"ProfilePicture" : "src/folders/resources/images/story/reformatted/img/hRI3TW31rC.img"
}
