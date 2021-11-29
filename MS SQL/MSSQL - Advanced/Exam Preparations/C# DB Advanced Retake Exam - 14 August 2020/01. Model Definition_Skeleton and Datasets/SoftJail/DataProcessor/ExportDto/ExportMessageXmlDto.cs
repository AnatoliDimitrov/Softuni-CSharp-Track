﻿using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class ExportMessageXmlDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
