using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogueEasy
{
    public class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public double HorsePower { get; set; }

        public Car(string brand, string model, double horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"{this.Brand}: {this.Model} - {this.HorsePower}hp";
        }
    }
}
