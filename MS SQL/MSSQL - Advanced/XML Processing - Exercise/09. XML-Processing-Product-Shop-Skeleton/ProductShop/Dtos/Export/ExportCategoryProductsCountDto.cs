
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class ExportCategoryProductsCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public string Count { get; set; }

        [XmlElement("averagePrice")]
        public string AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
