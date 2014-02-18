using System;
using System.Diagnostics;

class PrimitiveTypesComparison
{
    static void Main()
    {
        Console.WriteLine("int");
        Console.Write("add:\t\t");
        int intNumber = 5;
        DisplayExecutionTime(() =>
        {
            int result = intNumber + intNumber;
        });
        Console.Write("subtract:\t");
        DisplayExecutionTime(() =>
        {
            int result = intNumber - intNumber;
        });
        Console.Write("increment:\t");
        DisplayExecutionTime(() =>
        {
            intNumber++;
        });
        Console.Write("multiply:\t");
        DisplayExecutionTime(() =>
        {
            int result = intNumber * intNumber;
        });
        Console.Write("divide:\t\t");
        DisplayExecutionTime(() =>
        {
            int result = intNumber / intNumber;
        });
        Console.WriteLine();

        Console.WriteLine("long");
        Console.Write("add:\t\t");
        long longNumber = 5L;
        DisplayExecutionTime(() =>
        {
            long result = longNumber + longNumber;
        });
        Console.Write("subtract:\t");
        DisplayExecutionTime(() =>
        {
            long result = longNumber - longNumber;
        });
        Console.Write("increment:\t");
        DisplayExecutionTime(() =>
        {
            longNumber++;
        });
        Console.Write("multiply:\t");
        DisplayExecutionTime(() =>
        {
            long result = longNumber * longNumber;
        });
        Console.Write("divide:\t\t");
        DisplayExecutionTime(() =>
        {
            long result = longNumber / longNumber;
        });
        Console.WriteLine();

        Console.WriteLine("float");
        Console.Write("add:\t\t");
        float floatNumber = 5f;
        DisplayExecutionTime(() =>
        {
            float result = floatNumber + floatNumber;
        });
        Console.Write("subtract:\t");
        DisplayExecutionTime(() =>
        {
            float result = floatNumber - floatNumber;
        });
        Console.Write("increment:\t");
        DisplayExecutionTime(() =>
        {
            floatNumber++;
        });
        Console.Write("multiply:\t");
        DisplayExecutionTime(() =>
        {
            float result = floatNumber * floatNumber;
        });
        Console.Write("divide:\t\t");
        DisplayExecutionTime(() =>
        {
            float result = floatNumber / floatNumber;
        });
        Console.WriteLine();

        Console.WriteLine("double");
        Console.Write("add:\t\t");
        double doubleNumber = 5d;
        DisplayExecutionTime(() =>
        {
            double result = doubleNumber + doubleNumber;
        });
        Console.Write("subtract:\t");
        DisplayExecutionTime(() =>
        {
            double result = doubleNumber - doubleNumber;
        });
        Console.Write("increment:\t");
        DisplayExecutionTime(() =>
        {
            doubleNumber++;
        });
        Console.Write("multiply:\t");
        DisplayExecutionTime(() =>
        {
            double result = doubleNumber * doubleNumber;
        });
        Console.Write("divide:\t\t");
        DisplayExecutionTime(() =>
        {
            double result = doubleNumber / doubleNumber;
        });
        Console.WriteLine();

        Console.WriteLine("decimal");
        Console.Write("add:\t\t");
        decimal decimalNumber = 5m;
        DisplayExecutionTime(() =>
        {
            decimal result = decimalNumber + decimalNumber;
        });
        Console.Write("subtract:\t");
        DisplayExecutionTime(() =>
        {
            decimal result = decimalNumber - decimalNumber;
        });
        Console.Write("increment:\t");
        DisplayExecutionTime(() =>
        {
            decimalNumber++;
        });
        Console.Write("multiply:\t");
        DisplayExecutionTime(() =>
        {
            decimal result = decimalNumber * decimalNumber;
        });
        Console.Write("divide:\t\t");
        DisplayExecutionTime(() =>
        {
            decimal result = decimalNumber / decimalNumber;
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

