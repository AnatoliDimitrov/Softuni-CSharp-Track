using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("buyer")]
        public string BuyerName { get; set; }
    }
}
