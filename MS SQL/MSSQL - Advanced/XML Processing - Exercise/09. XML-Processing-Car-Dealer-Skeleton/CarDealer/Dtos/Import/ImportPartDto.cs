using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Part")]
    public class ImportPartDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("quantity")]
        public string Quantity { get; set; }

        [XmlElement("supplierId")]
        public string SupplierId { get; set; }
    }
}

//< name > Unexposed bumper </ name >
   
//    < price > 1003.34 </ price >
   
//    < quantity > 10 </ quantity >
   
//    < supplierId > 12 </ supplierId >
