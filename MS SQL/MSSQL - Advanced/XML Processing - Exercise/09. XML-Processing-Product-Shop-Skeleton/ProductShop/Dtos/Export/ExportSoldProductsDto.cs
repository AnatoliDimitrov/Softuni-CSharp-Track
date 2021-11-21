using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    
    public class ExportSoldProductsDto
    {
        [XmlElement("count")]
        public string Count { get; set; }

        [XmlArrayItem("Product")]
        [XmlArray("products")]
        public List<ExportSoldProductDto> Products { get; set; }
    }
}
