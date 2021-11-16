using System.Collections.Generic;
using CarDealer.Models;

namespace CarDealer.DTO
{
    public class CarOutputDto
    {
        public Car Car { get; set; }

        public IEnumerable<PartCar> Parts { get; set; }
    }
}
