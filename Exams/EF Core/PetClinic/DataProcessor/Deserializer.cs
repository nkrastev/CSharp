using Newtonsoft.Json;
using PetClinic.Data;
using PetClinic.DataProcessor.Dto.Import;
using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor
{
    public class Deserializer
    {
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessMessageAnimal = "Record {0} Passport №: {1} successfully imported.";
        private const string SuccessMessageProcedure = "Record successfully imported.";
        private const string ErrorMessage = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            List<AnimalAid> validAnimalAids = new List<AnimalAid>();            
            StringBuilder sb = new StringBuilder();
            ImportAnimalAidDto[] animalAidDtos = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString).ToArray();

            foreach (var animalAidDto in animalAidDtos)
            {
                if (!IsValid(animalAidDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }                
                if (context.AnimalAids.Any(x=>x.Name==animalAidDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validAnimalAid = new AnimalAid
                {
                    Name = animalAidDto.Name,
                    Price = animalAidDto.Price
                };
                validAnimalAids.Add(validAnimalAid);
                sb.AppendLine(String.Format(SuccessMessage, validAnimalAid.Name));
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            List<Animal> validAnimals = new List<Animal>();
            List<Passport> validPassports = new List<Passport>();

            StringBuilder sb = new StringBuilder();
            ImportAnimalDto[] animalDtos = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString).ToArray();

            foreach (var animalDto in animalDtos)
            {
                if (!IsValid(animalDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                if (!IsValid(animalDto.Passport))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //•	If a passport with the same serial number exists, do not import the entity
                if (context.Passports.Any(x=>x.SerialNumber==animalDto.Passport.SerialNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //validate date
                DateTime validDate;
                bool isDateValid = DateTime.TryParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);

                if (!isDateValid)
                {
                    //sb.AppendLine(animalDto.Passport.RegistrationDate);
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //create animal and passport
                Animal validAnimal = new Animal()
                {
                    Age = animalDto.Age,
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                };
                
                bool isValidDate = DateTime.TryParseExact(animalDto.Passport.RegistrationDate, "MM-dd-yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);
                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Passport validPassport = new Passport()
                {
                    OwnerName = animalDto.Passport.OwnerName,
                    Animal = validAnimal,
                    OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                    SerialNumber = animalDto.Passport.SerialNumber,
                    RegistrationDate = validDate
                };

                validAnimal.Passport = validPassport;
                validPassports.Add(validPassport);                
                validAnimals.Add(validAnimal);
                sb.AppendLine(String.Format(SuccessMessageAnimal, validAnimal.Name, validAnimal.Passport.SerialNumber));
            }

            
            context.Animals.AddRange(validAnimals);
            context.Passports.AddRange(validPassports);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportVetDto[] vetDtos = (ImportVetDto[])xmlSerializer.Deserialize(stringReader);

            sb.AppendLine("---Import Vets");

            List<Vet> validVets = new List<Vet>();

            foreach (var vetDto in vetDtos)
            {
                if (!IsValid(vetDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Vets.Any(x=>x.PhoneNumber==vetDto.PhoneNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Vet validVet = new Vet
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                validVets.Add(validVet);
                sb.AppendLine(String.Format(SuccessMessage, validVet.Name));
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {            
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportProcedureDto[] procedureDtos = (ImportProcedureDto[])xmlSerializer.Deserialize(stringReader);

            List<Procedure> validProcedures = new List<Procedure>();

            sb.AppendLine("---Import Procedures");

            foreach (var procedureDto in procedureDtos)
            {
                if (!IsValid(procedureDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Vet vet = context.Vets.FirstOrDefault(x => x.Name == procedureDto.VetName);

                Animal animal = context.Animals.FirstOrDefault(x => x.Passport.SerialNumber == procedureDto.AnimalSerialNumber);

                DateTime date;
                bool isValidDate = DateTime.TryParseExact(procedureDto.ProcedureDateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                if (vet == null || animal == null || !isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Procedure procedure = new Procedure()
                {
                    Animal = animal,
                    DateTime = date,
                    Vet = vet
                };

                foreach (var animalAidDto in procedureDto.AnimalAids)
                {
                    if (!IsValid(animalAidDto))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    AnimalAid animalAid = context.AnimalAids.FirstOrDefault(aa => aa.Name == animalAidDto.Name);

                    bool isProcedureHasAnimalAid = procedure.ProcedureAnimalAids.Any(p => p.AnimalAid.Name == animalAid.Name);

                    if (animalAid == null || isProcedureHasAnimalAid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    procedure.ProcedureAnimalAids.Add(new ProcedureAnimalAid()
                    {
                        AnimalAid = animalAid,
                        Procedure = procedure
                    });
                }

                validProcedures.Add(procedure);
                sb.AppendLine(SuccessMessageProcedure);
            }

            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}