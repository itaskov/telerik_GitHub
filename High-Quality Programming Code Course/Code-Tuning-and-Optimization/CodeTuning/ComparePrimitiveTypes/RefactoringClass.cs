using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ComparePrimitiveTypes
{
    class RefactoringClass
    {
        static void Main1()
        {
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
}
