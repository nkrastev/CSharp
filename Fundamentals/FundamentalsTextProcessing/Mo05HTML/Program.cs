using System;
using System.Text;

namespace Mo05HTML
{
    class Program
    {
        static void Main()
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string comment = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            sb.Append("<h1>");
            sb.AppendLine();
            sb.Append(title);
            sb.AppendLine();
            sb.Append("</h1>");
            sb.AppendLine();

            sb.Append("<article>");
            sb.AppendLine();
            sb.Append(content);
            sb.AppendLine();
            sb.Append("</article>");            

            while (comment!= "end of comments")
            {
                sb.AppendLine();
                sb.Append("<div>");
                sb.AppendLine();
                sb.Append(comment);
                sb.AppendLine();
                sb.Append("</div>");

                comment = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
