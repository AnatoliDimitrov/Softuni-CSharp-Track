using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => po.Officer)
                        .OrderBy(o => o.FullName)
                        .Select(o => new
                        {
                            OfficerName = o.FullName,
                            Department = o.Department.Name
                        })
                        .ToArray(),
                    TotalOfficerSalary = decimal.Parse(p.PrisonerOfficers
                        .Select(po => po.Officer).Sum(o => o.Salary).ToString("f2")),
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

                return JsonConvert.SerializeObject(prisoners, Formatting.Indented).TrimEnd();
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("Prisoners");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonerXmlDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .Select(p => new ExportPrisonerXmlDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                        .Select(m => new ExportMessageXmlDto
                        {
                            Description = String.Join("", m.Description.ToArray().Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();


            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }
    }
}