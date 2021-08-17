namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Tyre
    {
        private int age;
        private double pressure;

        public Tyre(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}
