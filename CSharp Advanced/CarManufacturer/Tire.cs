namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Tire
    {
        private int year;

        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; private set; }

        public double Pressure { get; private set; }

    }
}
