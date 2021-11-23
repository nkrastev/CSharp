namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            //Export All Prisoners with Cells and Officers by Ids
            var prisoners = context
                .Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o=>o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = Double.Parse(x.PrisonerOfficers.Sum(s => s.Officer.Salary).ToString("f2"))
                })
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id)
                .ToList();

            var output = JsonConvert.SerializeObject(prisoners, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonersStringList = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            var prisoners = context
                .Prisoners
                .ToArray()
                .Where(x => prisonersStringList.Contains(x.FullName))
                .Select(x => new ExportPrisonerDto()
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(m => new ExportMailDto()
                    {
                        Description = ReverseString(m.Description)
                    })
                    .ToArray(),
                })
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            xml.Serialize(new StringWriter(sb), prisoners, namespaces);
            return sb.ToString().Trim();
        }

        public static string ReverseString(string input)
        {
            if (input == null) return "";            
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new String(array);           
        }
    }
}