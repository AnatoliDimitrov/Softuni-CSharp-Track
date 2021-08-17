namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car
    {
        private string model;
        private string color;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;
        private double weight;
        private Engine engine;
        private Cargo cargo;
        private List<Tyre> tyres;


        public Car(string model, Engine engine, double weight = 0, string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }


        public List<Tyre> Tyres
        {
            get { return tyres; }
            set { tyres = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double Travelled
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public bool HasTyresWithLowPressure()
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.tyres[i].Pressure < 1)
                {
                    return true;
                }
            }
            return false;
        }

        public void Drive(double amountOfKM)
        {
            double fuelNeeded = amountOfKM * this.FuelConsumptionPerKilometer;

            if (fuelNeeded <= this.FuelAmount)
            {
                this.FuelAmount -= fuelNeeded;
                this.Travelled += amountOfKM;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Model}:");
            result.AppendLine($"  {this.Engine.Model}:");
            result.AppendLine($"    Power: {this.Engine.Power}");

            if (this.Engine.Displacement == 0)
            {
                result.AppendLine($"    Displacement: n/a");
            }
            else
            {
                result.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }

            result.AppendLine($"    Efficiency: {this.Engine.Efficiency}");

            if (this.Weight == 0)
            {
                result.AppendLine($"  Weight: n/a");
            }
            else
            {
                result.AppendLine($"  Weight: {this.Weight}");
            }

            result.Append($"  Color: {this.Color}");

            return result.ToString();
        }
    }
}
