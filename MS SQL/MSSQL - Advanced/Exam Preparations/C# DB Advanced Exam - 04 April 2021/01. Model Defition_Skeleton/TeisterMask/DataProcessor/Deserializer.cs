using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

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
            var result = new StringBuilder();

            using StringReader reader = new StringReader(xmlString);

            XmlRootAttribute root = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectXMLDto[]), root);

            var dtos = (ImportProjectXMLDto[])serializer.Deserialize(reader);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    result.AppendLine("Invalid data!");
                    continue;
                }

                var project = new Project();
                var prOdate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var isDate = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var prDDate);

                foreach (var taskDto in dto.Tasks)
                {
                    
                }
                //var tOdate = DateTime.ParseExact(dto.Tasks, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //var tDdate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
            //context.SaveChanges();

            return $"Successfully imported {dtos.Length}";
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}