namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportProjectDto[] projectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(stringReader);

            List<Project> projects = new List<Project>();

            foreach (ImportProjectDto projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime dueDateDt;
                    bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateDt);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateDt;
                }

                Project p = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (ImportProjectTasksDto taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && taskDueDate > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    p.Tasks.Add(t);
                }

                projects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, p.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> employees = new List<Employee>();

            foreach (ImportEmployeeDto employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task t = context.Tasks.Find(taskId);

                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    e.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = t
                    });
                }

                employees.Add(e);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
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