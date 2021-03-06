using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {

        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * (radius * radius);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public override string Draw()
        {
            StringBuilder result = new StringBuilder();

            double In = this.radius - 0.4;

            double Out = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {

                for (double x = -this.radius; x < Out; x += 0.5)
                {

                    double value = x * x + y * y;

                    if (value >= In * In && value <= Out * Out)
                    {
                        result.Append("*");
                    }
                    else
                    {
                        result.Append(" ");
                    }
                }

                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }
    }
}
