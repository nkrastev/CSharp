using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Instagraph.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        //UNIQUE!!!
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public int? ProfilePictureId { get; set; }

        public Picture ProfilePicture { get; set; }

        public virtual ICollection<UserFollower> Followers { get; set; } = new HashSet<UserFollower>();

        public virtual ICollection<UserFollower> UsersFollowing { get; set; } = new HashSet<UserFollower>();

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }

    //    •	Id – an integer, Primary Key
    //•	Username – a string with max length 30, Unique
    //•	Password – a string with max length 20
    //•	ProfilePictureId – an integer
    //•	ProfilePicture – a Picture
    //•	Followers – a Collection of type UserFollower
    //•	UsersFollowing – a Collection of type UserFollower
    //•	Posts – a Collection of type Post
    //•	Comments – a Collection of type Comment

}