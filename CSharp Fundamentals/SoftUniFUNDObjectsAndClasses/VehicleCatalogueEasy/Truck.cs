using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogueEasy
{
    public class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public double Weight { get; set; }

        public Truck(string brand, string model, double weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"{this.Brand}: {this.Model} - {this.Weight}kg";
        }
    }
}
