using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        static string ConvertNumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";

                default: throw new ArgumentException("Invalid number!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Elements can not be null or empty.");
            }

            int max = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        static void PrintAsFixedPrecision(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        static void PrintAsPercentage(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        static void PrintAsIdentical(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));
            
            return Math.Sqrt(distance);
        }

        static bool IsHorisontal(double y1, double y2)
        {
            return y1 == y2;
        }

        static bool IsVertical(double x1, double x2)
        {
            return x1 == x2;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertNumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFixedPrecision(1.3);
            PrintAsPercentage(0.75);
            PrintAsIdentical(2.30m);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine(CalcDistance(-1, 0, 0, 0));

            Console.WriteLine("Horizontal: {0}", IsHorisontal(-1, 2.5));
            Console.WriteLine("Vertical: {0}", IsVertical(3, 3));

            Student peter = new Student() 
            { 
                FirstName = "Peter", 
                LastName = "Ivanov", 
                BirthDate = new DateTime(1992, 3, 17),
                OtherInfo = "From Sofia, born at 17.03.1992"
            };

            Student stella = new Student() 
            { 
                FirstName = "Stella", 
                LastName = "Markova",
                BirthDate = new DateTime(1993, 11, 3),
                OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993"
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
