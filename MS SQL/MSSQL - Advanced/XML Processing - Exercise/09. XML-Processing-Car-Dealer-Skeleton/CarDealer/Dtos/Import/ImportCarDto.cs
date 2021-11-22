using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public string TravelledDistance { get; set; }

        [XmlArray("parts")]
        [XmlArrayItem("partId")]
        public List<ImportCarPartDto> PartCars { get; set; }
    }
}
