using System;

class SizeMeasurement
{
    static void Main()
    {

    }

    public class Size
    {
        public double Width {get; set;} 
        public double Height {get; set;}
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }

    public static class SizeCalculations
    {
        public static Size GetRotatedSize(Size size, double rotatedFigureAngel)
        {
            double sin = Math.Abs(Math.Sin(rotatedFigureAngel));
            double cos = Math.Abs(Math.Cos(rotatedFigureAngel));

            double rotatedWidth = cos * size.Width + sin * size.Height;
            double rotatedHeight = sin * size.Width * cos * size.Height;

            var rotatedSize = new Size(rotatedWidth, rotatedHeight);

            return rotatedSize;
        }
    }

}



