using Instagraph.Data;
using Instagraph.DataProcessor.DtoModels;
using Instagraph.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{

    public class Deserializer
    {
        private static string successMessage = "Successfully imported {0}.";
        private static string errorMessage = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            List<Picture> validPictures = new List<Picture>();
            StringBuilder sb = new StringBuilder();

            ImportPictureDto[] pictureDtos = JsonConvert.DeserializeObject<ImportPictureDto[]>(jsonString).ToArray();

            foreach (var pictureDto in pictureDtos)
            {
                //validate via DTO
                if (!IsValid(pictureDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                //validate path uniqueness
                if (context.Pictures.Any(x=>x.Path==pictureDto.Path))
                {
                    sb.AppendLine(errorMessage);
                }

                Picture validPicture = new Picture
                {
                    Path = pictureDto.Path,
                    Size = pictureDto.Size
                };

                validPictures.Add(validPicture);
                sb.AppendLine(String.Format(successMessage, $"Picture {validPicture.Path}"));
            }
            context.Pictures.AddRange(validPictures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            List<User> validUsers = new List<User>();
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString).ToArray();

            foreach (var userDto in userDtos)
            {
                //validate via DTO
                if (!IsValid(userDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                //uniqueness of username
                if (context.Users.Any(x=>x.Username==userDto.Username))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var picture = context.Pictures.FirstOrDefault(p => p.Path == userDto.ProfilePicture);

                if (picture == null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                User user = new User
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    ProfilePicture = picture
                };

                validUsers.Add(user);
                sb.AppendLine(String.Format(successMessage, $"User {user.Username}"));
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            //To make someone a follower of another user, both of them must exist in the database
            List<UserFollower> validDataForContext = new List<UserFollower>();
            StringBuilder sb = new StringBuilder();

            ImportUserFollowerDto[] userFollowerDtos = JsonConvert.DeserializeObject<ImportUserFollowerDto[]>(jsonString).ToArray();

            foreach (var userFollowerDto in userFollowerDtos)
            {
                //validate via DTO
                if (!IsValid(userFollowerDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                //check if both exists
                var user = context.Users.Where(x => x.Username == userFollowerDto.User).FirstOrDefault();
                var follower = context.Users.Where(x => x.Username == userFollowerDto.Follower).FirstOrDefault();
                var isFollowing = validDataForContext.Any(u => u.User == user && u.Follower == follower);

                //can user follow itself?
                if (user==null || follower==null || isFollowing || user.Id == follower.Id)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }                

                UserFollower validUserFollower = new UserFollower
                {
                    User = user,
                    Follower = follower
                };

                validDataForContext.Add(validUserFollower);
                sb.AppendLine(String.Format(successMessage, $"Follower {follower.Username} to User {user.Username}"));
            }
            
            context.UserFollowers.AddRange(validDataForContext);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPostDto[]), new XmlRootAttribute("posts"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportPostDto[] postDtos = (ImportPostDto[])xmlSerializer.Deserialize(stringReader);

            List<Post> validDataForContext = new List<Post>();

            foreach (var postDto in postDtos)
            {
                if (!IsValid(postDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                //A post should only be inserted if the user and picture already exist in the database.
                User user= context.Users.FirstOrDefault(x => x.Username == postDto.Username);
                Picture picture= context.Pictures.FirstOrDefault(x => x.Path == postDto.PictureUrl);

                if (user==null || picture== null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Post validPost = new Post
                {
                    User = user,
                    Caption = postDto.Caption,
                    Picture = picture,
                    UserId = user.Id,
                    PictureId = picture.Id
                };

                validDataForContext.Add(validPost);
                sb.AppendLine($"Successfully imported Post {validPost.Caption}.");
            }
            context.Posts.AddRange(validDataForContext);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCommentDto[]), new XmlRootAttribute("comments"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportCommentDto[] commentDtos = (ImportCommentDto[])xmlSerializer.Deserialize(stringReader);

            List<Comment> validDataForContext = new List<Comment>();

            foreach (var commentDto in commentDtos)
            {
                if (!IsValid(commentDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                //Comments should only be added for existing users and posts.                

                User user = context.Users.FirstOrDefault(x => x.Username == commentDto.Username);
                Post post = context.Posts.FirstOrDefault(x => x.Id == commentDto.Post.Id);                

                if (user==null || post==null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Comment validComment = new Comment
                {
                    User = user,
                    Post = post,
                    Content = commentDto.Content
                };

                validDataForContext.Add(validComment);
                sb.AppendLine($"Successfully imported Comment {validComment.Content}.");
            }

            context.Comments.AddRange(validDataForContext);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();
            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
