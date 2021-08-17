using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : IDrawable
    {

        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return width; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                height = value; 
            }
        }


        public void Draw()
        {

            Console.WriteLine(new string('*', this.Width));

            for (int i = 1; i < this.Height - 1; i++)
            {
                Console.WriteLine("*" + new string(' ', this.Width - 2) + "*");
            }

            Console.WriteLine(new string('*', this.Width));
        }
    }
}
