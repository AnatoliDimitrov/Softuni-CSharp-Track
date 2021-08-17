using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                radius = value;
            }
        }

        public void Draw()
        {

            double In = this.radius - 0.4;

            double Out = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {

                for (double x = -this.Radius; x < Out; x += 0.5)
                {

                    double value = x * x + y * y;

                    if (value >= In * In && value <= Out * Out)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
