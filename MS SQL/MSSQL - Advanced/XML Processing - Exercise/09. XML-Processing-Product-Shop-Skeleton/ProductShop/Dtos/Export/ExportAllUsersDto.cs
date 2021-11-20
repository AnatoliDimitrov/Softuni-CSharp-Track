using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class ExportAllUsersDto
    {
        [XmlElement("count")]
        public string Count { get; set; }

        [XmlArray("users")]
        [XmlArrayItem("User")]
        public List<ExportUserDto> Users { get; set; }
    }
}
