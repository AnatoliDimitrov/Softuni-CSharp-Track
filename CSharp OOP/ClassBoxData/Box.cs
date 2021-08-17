using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.length = ValidateSide(value, nameof(Box.Length));
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = ValidateSide(value, nameof(Box.Width));
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.height = ValidateSide(value, nameof(Box.Height));
            }
        }

        private double ValidateSide(double side, string witchSide)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{witchSide} cannot be zero or negative.");
            }

            return side;
        }

        public string SurfaceArea()
        {
            double result =  (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);

            return $"Surface Area - {result:F2}";
        }

        public string LateralSurfaceArea()
        {
            double result = (2 * Length * Height) + (2 * Width * Height);

            return $"Lateral Surface Area - {result:F2}";
        }

        public string Volume()
        {
            double result = length * width * Height;

            return $"Volume - {result:F2}";
        }
    }
}
