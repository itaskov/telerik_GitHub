using System;

public class Print
{
    public static void Main(string[] args)
    {
    }

    public void PrintStatistics(double[] pricesList, int pricesListCount)
    {
        double max = GetMaxPrice(pricesList, pricesListCount);
        PrintPrice(max);

        double min = GetMinPrice(pricesList, pricesListCount);
        PrintPrice(min);

        double average = GetAveragePrice(pricesList, pricesListCount);
        PrintPrice(average);
    }

    private static double GetMaxPrice(double[] pricesList, int pricesListCount)
    {
        double max = 0d;

        for (int i = 0; i < pricesListCount; i++)
        {
            if (pricesList[i] > max)
            {
                max = pricesList[i];
            }
        }

        return max;
    }

    private static void PrintPrice(double price)
    {
        Console.WriteLine(price);
    }

    private static double GetMinPrice(double[] pricesList, int pricesListCount)
    {
        double min = 0d;

        for (int i = 0; i < pricesListCount; i++)
        {
            if (pricesList[i] < min)
            {
                min = pricesList[i];
            }
        }

        return min;
    }

    private static double GetAveragePrice(double[] pricesList, int pricesListCount)
    {
        double average = 0d;

        for (int i = 0; i < pricesListCount; i++)
        {
            average += pricesList[i];
        }

        average /= pricesListCount;

        return average;
    }
}