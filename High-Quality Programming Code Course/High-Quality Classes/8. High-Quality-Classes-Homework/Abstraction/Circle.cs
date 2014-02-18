using System;

namespace Abstraction
{
    class Circle : Figure
    {
        public double Radius 
        {
            get
            {
                return this.Radius;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("radius");
                }
                this.Radius = value;
            }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
       
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
