namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {

            //jsonString= @"[{'Name':'','Cells':[]},{'Name':'Invaliiiiiiiiiiiiiiiiiiiiiiiiiiiiidddddd','Cells':[]},{'Name':'Test','Cells':[{'CellNumber':0,'HasWindow':true}]},{'Name':'Test','Cells':[{'CellNumber':1001,'HasWindow':true}]}]";

            StringBuilder sb = new StringBuilder();
            ImportDepartmentDto[] departmentsDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString).ToArray();

            List<Department> validDepartments = new List<Department>();

            foreach (var departmentDto in departmentsDtos)
            {
                //validated in dto
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name
                };

                List<Cell> cells = new List<Cell>();
                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        cells = new List<Cell>();
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        Department = department,
                        HasWindow = cellDto.HasWindow
                    };
                    cells.Add(cell);

                }

                if (!cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                department.Cells = cells;
                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");

            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();            
            return sb.ToString().TrimEnd();        
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPrisonerDto[] prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString).ToArray();
            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDtos)
            {                

                //validated in dto
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //IncarcerationDate validation and ReleaseDate (release date can be null and valid)
                DateTime incercerationDate;
                bool isDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incercerationDate);
                if (!isDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                DateTime releaseDate;                
                bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);
                if (prisonerDto.ReleaseDate!=null && !isReleaseDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                                

                //prisoner is valid, create it
                Prisoner  validPrisoner = new Prisoner()
                {
                    FullName=prisonerDto.FullName,
                    Nickname=prisonerDto.Nickname,
                    Age=prisonerDto.Age,
                    IncarcerationDate=incercerationDate,
                    ReleaseDate=releaseDate,                    
                    Bail= prisonerDto.Bail,
                    CellId=prisonerDto.CellId
                };

                //mail validation

                List<Mail> mails = new List<Mail>();
                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        mails = new List<Mail>();
                        break;
                    }
                    Mail mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };
                    mails.Add(mail);
                }

                validPrisoner.Mails = mails;
                validPrisoners.Add(validPrisoner);
                sb.AppendLine($"Imported {validPrisoner.FullName} {validPrisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportOfficerDto[] officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);

            List<Officer> validOfficers = new List<Officer>();

            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                //create valid officer
                Officer validOfficer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money
                };

                //validate enums
                Position position;
                bool isValidPosition = Enum.TryParse(officerDto.Position, out position);
                if (!isValidPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                validOfficer.Position = position;

                Weapon weapon;
                bool isValidWeapon = Enum.TryParse(officerDto.Weapon, out weapon);
                if (!isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                validOfficer.Weapon = weapon;

                //validate DepartmentId
                if (!context.Departments.Any(x=>x.Id==officerDto.DepartmentId))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                validOfficer.DepartmentId = officerDto.DepartmentId;

                foreach (var prisonerDto in officerDto.Prisoners)
                {                    
                    validOfficer.OfficerPrisoners.Add(new OfficerPrisoner()
                    {
                        //•	The prisoner Id will always be valid
                        Officer = validOfficer,
                        PrisonerId = prisonerDto.Id
                    });
                }

                validOfficers.Add(validOfficer);
                sb.AppendLine($"Imported {validOfficer.FullName} ({validOfficer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}