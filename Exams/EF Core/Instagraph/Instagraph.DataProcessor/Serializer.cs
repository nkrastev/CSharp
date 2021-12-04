using Instagraph.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            //Export all posts which do NOT have ANY comments.Extract everything and order it by id in ascending order.
            //Extract the Id, Path as "Picture" and the poster’s Username as "User".
            var posts = context
                .Posts
                .Where(x => x.Comments.Count == 0)
                .Select(x => new
                {
                    Id=x.Id,
                    Picture=x.Picture.Path,
                    User=x.User.Username
                })
                .OrderBy(x=>x.Id)
                .ToList();


            var output = JsonConvert.SerializeObject(posts, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
                //NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {            
            var users=context
                .Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(f => f.FollowerId == c.UserId))))
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Username = u.Username,
                    Followers = u.Followers.Count
                })
                .ToList();

            var output = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented                
            });

            return output;            
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            
            var users = context
                .Users
                .Select(u => new
                {
                    Username = u.Username,
                    Comments = u.Posts
                        .Select(p => p.Comments.Count)
                        .ToList()
                });

            var dtos = new List<ExportUsersDto>();

            foreach (var dto in users)
            {
                var mostComments = 0;

                if (dto.Comments.Any())
                {
                    mostComments = dto.Comments
                        .OrderByDescending(c => c)
                        .First();
                }

                var user = new ExportUsersDto()
                {
                    Username = dto.Username,
                    MostComments = mostComments
                };

                dtos.Add(user);
            }

            dtos=dtos.OrderByDescending(x => x.MostComments).ToList();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(List<ExportUsersDto>), new XmlRootAttribute("users"));
            xml.Serialize(new StringWriter(sb), dtos, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}
