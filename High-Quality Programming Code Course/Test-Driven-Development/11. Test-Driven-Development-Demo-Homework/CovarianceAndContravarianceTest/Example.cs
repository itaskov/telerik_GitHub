using System;
using System.Collections.Generic;

class Example
{
    static void Main()
    {
        // You can pass ShapeAreaComparer, which implements IComparer<Shape>, 
        // even though the constructor for SortedSet<Circle> expects  
        // IComparer<Circle>, because type parameter T of IComparer<T> is 
        // contravariant.
        SortedSet<Circle> circlesByArea =
            new SortedSet<Circle>(new ShapeAreaComparer()) { new Circle(7.2), new Circle(100), null, new Circle(.01) };
            //new SortedSet<Circle>(new SpecialCircleAreaComparer()) { new Circle(7.2), new Circle(100), null, new Circle(.01) };

        foreach (Circle c in circlesByArea)
        {
            Console.WriteLine(c == null ? "null" : "Circle with area " + c.Area);
        }


        Func<SpecialCircle> objectFunc = () => (SpecialCircle)new Circle(5);
        Console.WriteLine(objectFunc().Area);
    }
}

abstract class Shape
{
    public virtual double Area { get { return 0; } }
}

class Circle : Shape
{
    private double r;
    public Circle(double radius) { r = radius; }
    public double Radius { get { return r; } }
    public override double Area { get { return Math.PI * r * r; } }
}

class SpecialCircle : Circle
{
    public SpecialCircle(double radius) : base(radius){  }
    public override double Area { get { return 100; } }
}

class ShapeAreaComparer : System.Collections.Generic.IComparer<Shape>
{
    int IComparer<Shape>.Compare(Shape a, Shape b)
    {
        if (a == null) return b == null ? 0 : -1;
        return b == null ? 1 : a.Area.CompareTo(b.Area);
    }
}

class SpecialCircleAreaComparer : System.Collections.Generic.IComparer<SpecialCircle>
{
    int IComparer<SpecialCircle>.Compare(SpecialCircle a, SpecialCircle b)
    {
        if (a == null) return b == null ? 0 : -1;
        return b == null ? 1 : a.Area.CompareTo(b.Area);
    }
}