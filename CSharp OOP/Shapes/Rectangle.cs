using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return this.width * this.height;
        }

        public override double CalculatePerimeter()
        {
            return (this.width * 2) + (this.height * 2);
        }

        public override string Draw()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(new string('*', (int)this.width));

            for (int i = 1; i < this.height - 1; i++)
            {
                result.AppendLine("*" + new string(' ', (int)this.width - 2) + "*");
            }

            result.AppendLine(new string('*', (int)this.width));

            return result.ToString().Trim();
        }
    }
}
