using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<ImportDepartmentWithCellsJsonDto>>(jsonString).ToList();

            //var departments = new List<Department>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !dto.Cells.All(IsValid) || dto.Cells.Length == 0)
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department()
                {
                    Name = dto.Name
                };

                foreach (var cellDto in dto.Cells)
                {
                    var cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    department.Cells.Add(cell);
                }

                result.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                context.Departments.Add(department);
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<ImportPrisonerWithMailsJsonDto>>(jsonString).ToList();

            foreach (var dto in dtos)
            {
                var IsValidIncarcerationDate = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                var IsValidReleaseDate = DateTime.TryParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);


                if (!IsValid(dto) || !dto.Mails.All(IsValid) || !IsValidIncarcerationDate)
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new Prisoner()
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = IsValidReleaseDate ? releaseDate : (DateTime?) null,
                    Bail = dto.Bail,
                    CellId = dto.CellId
                };

                foreach (var mailDto in dto.Mails)
                {
                    var mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                    };

                    prisoner.Mails.Add(mail);
                }

                result.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                context.Prisoners.Add(prisoner);
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var result = new StringBuilder();

            using StringReader reader = new StringReader(xmlString);

            XmlRootAttribute root = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerXmlDto[]), root);

            var dtos = (ImportOfficerXmlDto[])serializer.Deserialize(reader);

            var officers = new List<Officer>();

            foreach (var dto in dtos)
            {
                var isValidPosition = Enum.TryParse<Position>(dto.Position, out Position position);
                var isValidWeapon = Enum.TryParse<Weapon>(dto.Weapon, out Weapon weapon);

                if (!IsValid(dto) || !isValidPosition || !isValidWeapon)
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = dto.Name,
                    Salary = dto.Money,
                    Weapon = weapon,
                    Position = position,
                    DepartmentId = dto.DepartmentId
                };

                foreach (var prisonerDto in dto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner(){PrisonerId = prisonerDto.Id});
                }

                result.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                context.Officers.Add(officer);
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
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