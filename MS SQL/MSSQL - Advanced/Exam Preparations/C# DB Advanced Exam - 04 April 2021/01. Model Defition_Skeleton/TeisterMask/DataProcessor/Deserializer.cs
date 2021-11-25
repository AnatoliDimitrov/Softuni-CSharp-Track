using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
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

                var isODate = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var projectOpenDate);
                var isDDate = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var projectDueDate);

                if (!isODate)
                {
                    result.AppendLine("Invalid data!");
                    continue;
                }

                Project project = new Project()
                {
                    Name = dto.Name,
                    OpenDate = projectOpenDate,
                };

                if (isDDate)
                {
                    project.DueDate = projectDueDate;
                }
                else
                {
                    project.DueDate = null;
                }

                foreach (var taskDto in dto.Tasks)
                {
                    var isTaskOpenDate = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var taskOpenDate);
                    var isTaskDueDate = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var taskDueDate);

                    if (IsValid(taskDto) && ValidateDates(isDDate, isODate, projectOpenDate, projectDueDate, isTaskOpenDate, isTaskDueDate, taskOpenDate, taskDueDate))
                    {
                        Task task = new Task()
                        {
                            Name = taskDto.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            ExecutionType = (ExecutionType)taskDto.ExecutionType,
                            LabelType = (LabelType)taskDto.LabelType,
                        };

                        project.Tasks.Add(task);
                    }
                    else
                    {
                        result.AppendLine("Invalid data!");
                    }
                }

                context.Projects.Add(project);
                result.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool ValidateDates(bool isDDate, bool isODate, DateTime projectOpenDate, DateTime projectDueDate, bool isTaskOpenDate, bool isTaskDueDate, DateTime taskOpenDate, DateTime taskDueDate)
        {
            if (!isTaskDueDate || !isTaskOpenDate)
            {
                return false;
            }

            if (taskOpenDate < projectOpenDate || (isDDate && taskDueDate > projectDueDate))
            {
                return false;
            }

            return true;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var result = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    result.AppendLine("Invalid data!");
                    continue;
                }

                var employee = new Employee()
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                };

                foreach (var taskDto in dto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskDto);

                    if (task == null)
                    {
                        result.AppendLine("Invalid data!");
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask(){ Task = task });
                }

                context.Employees.Add(employee);
                result.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}