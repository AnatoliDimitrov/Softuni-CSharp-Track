using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUserWithSoldProducts
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArrayItem("Product")]
        [XmlArray("soldProducts")]
        public List<ExportSoldProductDto> ProductsSold { get; set; }
    }
}
