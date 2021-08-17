using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogue
{
    public class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public double HorsePower { get; set; }

        public Vehicle(string type, string model, string color, double horsePower)
        {
            if (type == "car" || type == "Car")
            {
                this.Type = "Car";
            }
            else
            {
                this.Type = "Truck";
            }
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"Type: {this.Type}\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.HorsePower}";
        }
    }
}
