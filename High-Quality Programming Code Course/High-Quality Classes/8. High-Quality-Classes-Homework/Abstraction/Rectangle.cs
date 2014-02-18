using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        public double Width 
        {
            get
            {
                return this.Width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("width");
                }
                this.Width = value;
            }
        }

        public double Height 
        {
            get
            {
                return this.Height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("height");
                }
                this.Height = value;
            }
        }
        
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
