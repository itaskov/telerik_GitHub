using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4 };
        int sum = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            sum += arr[i];
        }

        Console.WriteLine(sum);
    }

    static void AddNewMethod()
    {

    }
}

