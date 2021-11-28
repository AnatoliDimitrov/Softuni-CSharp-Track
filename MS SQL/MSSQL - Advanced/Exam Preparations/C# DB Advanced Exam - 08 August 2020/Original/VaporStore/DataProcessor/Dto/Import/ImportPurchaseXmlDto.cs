using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseXmlDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public PurchaseType? Type { get; set; }

        [XmlElement("Key")]
        [RegularExpression(@"^[0-9A-Z]{4}-[0-9A-Z]{4}-[0-9A-Z]{4}$")]
        public string Key { get; set; }

        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
