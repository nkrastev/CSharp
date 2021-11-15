namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects                   
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ExportProjectDto()
                {
                    TasksCount=x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate ==null ? "No" : "Yes",
                    Tasks = x.Tasks.ToArray().Select(z => new ExportTaskDto()
                    {
                        Name = z.Name,
                        Label = z.LabelType.ToString()
                    })
                    .OrderBy(t=>t.Name)   
                    .ToArray()
                })                
                .OrderByDescending(p=>p.TasksCount)
                .ThenBy(p=>p.ProjectName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));
            xml.Serialize(new StringWriter(sb), projects, namespaces);
            return sb.ToString().Trim();            
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(x => x.EmployeesTasks.Any(z => z.Task.OpenDate >= date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(d => d.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t=>t.Task.Name)
                    .Select(z => new
                    {
                        TaskName=z.Task.Name,
                        OpenDate= z.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate= z.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType =z.Task.LabelType.ToString(),
                        ExecutionType=z.Task.ExecutionType.ToString()
                    })                                        
                    .ToList()
                }).ToList()
                .OrderByDescending(x=>x.Tasks.Count)
                .ThenBy(x=>x.Username)
                .Take(10)
                .ToList();

            var output = JsonConvert.SerializeObject(employees, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }
    }
}