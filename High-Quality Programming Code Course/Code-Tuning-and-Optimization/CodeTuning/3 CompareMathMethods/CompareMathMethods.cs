using System;
using System.Diagnostics;

class CompareMathMethods
{
    static void Main()
    {
        Console.WriteLine("float");
        Console.Write("sqrt:\t\t");
        float floatNumber = 2.23F;
        DisplayExecutionTime(() =>
        {
            float result = (float)Math.Sqrt(floatNumber);
        });
        Console.Write("logarithm:\t");
        DisplayExecutionTime(() =>
        {
            float result = (float)Math.Log(floatNumber);
        });
        Console.Write("sin:\t\t");
        DisplayExecutionTime(() =>
        {
            float result = (float)Math.Sin(floatNumber);
        });
        Console.WriteLine();

        Console.WriteLine("double");
        Console.Write("sqrt:\t\t");
        double doubleNumber = 2.23d;
        DisplayExecutionTime(() =>
        {
            double result = Math.Sqrt(doubleNumber);
        });
        Console.Write("logarithm:\t");
        DisplayExecutionTime(() =>
        {
            double result = Math.Log(doubleNumber);
        });
        Console.Write("sin:\t\t");
        DisplayExecutionTime(() =>
        {
            double result = Math.Sin(doubleNumber);
        });
        Console.WriteLine();

        Console.WriteLine("decimal");
        Console.Write("sqrt:\t\t");
        decimal decimalNumber = 2.23m;
        DisplayExecutionTime(() =>
        {
            decimal result = (decimal)Math.Sqrt((double)decimalNumber);
        });
        Console.Write("logarithm:\t");
        DisplayExecutionTime(() =>
        {
            decimal result = (decimal)Math.Log((double)decimalNumber);
        });
        Console.Write("sin:\t\t");
        DisplayExecutionTime(() =>
        {
            decimal result = (decimal)Math.Sin((double)decimalNumber);
        });
        Console.WriteLine();
    }

    static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }
}

