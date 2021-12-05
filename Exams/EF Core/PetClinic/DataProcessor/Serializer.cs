using Newtonsoft.Json;
using PetClinic.Data;
using PetClinic.DataProcessor.Dto.Export;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor
{
    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context
                .Animals
                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.Passport.SerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                })
                .OrderBy(x=>x.Age)
                .ThenBy(x=>x.SerialNumber)
                .ToList();


            var output = JsonConvert.SerializeObject(animals, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
                //NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var allProcedures = context
                .Procedures
                .ToArray()
                .OrderBy(o=>o.DateTime)
                .ThenBy(o=>o.Animal.PassportSerialNumber)
                .Select(x => new ExportAllProceduresDto
                {
                    Passport = x.Animal.PassportSerialNumber,
                    OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = x.ProcedureAnimalAids.Select(p => new ExportAnimalAidDto
                    {
                        Name=p.AnimalAid.Name,
                        Price=p.AnimalAid.Price
                    })
                    .ToArray(),                    
                    TotalPrice = Math.Round(x.ProcedureAnimalAids.Sum(pr => pr.AnimalAid.Price), 2, MidpointRounding.AwayFromZero)
                    
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xml = new XmlSerializer(typeof(ExportAllProceduresDto[]), new XmlRootAttribute("Procedures"));
            xml.Serialize(new StringWriter(sb), allProcedures, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}