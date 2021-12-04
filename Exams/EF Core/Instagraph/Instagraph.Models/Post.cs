using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Instagraph.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Caption { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public int? PictureId { get; set; }

        public Picture Picture { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }

    //    •	Id – an integer, Primary Key
    //•	Caption – a string
    //•	UserId – an integer
    //•	User – a User
    //•	PictureId – an integer
    //•	Picture – a Picture
    //•	Comments – a Collection of type Comment

}