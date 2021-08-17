namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engine
    {
        private int speed,
            power;
        private double displacement;
        private string efficiency;
        private string model;

        public Engine(string model, int power, double displacement = 0, string efficiency = "n/a")
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public double Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}
