using System;


public class WalkInMatrix
{
    public const int MIN_NUMBER = 1;

    public const int MAX_NUMBER = 100;

    public const int DIRECTION_COUNT = 8;

    static int ReadInput()
    {
        return 4;

        Console.Write("Enter a positive number: ");
        string input = Console.ReadLine();
        int result;
        while (!int.TryParse(input, out result) || result < MIN_NUMBER || result > MAX_NUMBER)
        {
            Console.WriteLine("Invalid number! Value must be between 1 and 100.");
            Console.Write("Enter a positive number: ");
            input = Console.ReadLine();
        }

        return result;
    }

    static void ChangeDirection(ref int directionX, ref int directionY)
    {
        int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        int directionCount = 0;
        for (int index = 0; index < DIRECTION_COUNT; index++)
        {
            if (dirX[index] == directionX && dirY[index] == directionY)
            {
                directionCount = index;
                break;
            }
        }

        if (directionCount == 7)
        {
            directionX = dirX[0];
            directionY = dirY[0];
            return;
        }

        directionX = dirX[directionCount + 1];
        directionY = dirY[directionCount + 1];
    }
    static bool CheckForEmptyCell(int[,] arr, int row, int col)
    {
        int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < DIRECTION_COUNT; i++)
        {
            if (row + dirX[i] >= arr.GetLength(0) || row + dirX[i] < 0)
            {
                dirX[i] = 0;
            }

            if (col + dirY[i] >= arr.GetLength(1) || col + dirY[i] < 0)
            {
                dirY[i] = 0;
            }
        }

        for (int i = 0; i < DIRECTION_COUNT; i++)
        {
            if (arr[row + dirX[i], col + dirY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    static void GetStartCell(int[,] martix, out int row, out int col)
    {
        row = 0;
        col = 0;
        for (int i = 0; i < martix.GetLength(0); i++)
        {
            for (int j = 0; j < martix.GetLength(1); j++)
            {
                if (martix[i, j] == 0)
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int n = ReadInput();
        int[,] matrix = new int[n, n];
        int cellValue = MIN_NUMBER, row = 0, col = 0, directionX = 1, directionY = 1;
        
        WriteInMatrix(n, matrix, ref cellValue, ref row, ref col, ref directionX, ref directionY);

        GetStartCell(matrix, out row, out col);
        
        WriteInMatrix(n, matrix, ref cellValue, ref row, ref col, ref directionX, ref directionY);
        
        PrintToConsole(matrix);
    }

    private static void WriteInMatrix(int n, int[,] matrix, ref int cellValue, ref int row, ref int col, ref int directionX, ref int directionY)
    {
        while (true)
        { //malko e kofti tova uslovie, no break-a raboti 100% : )
            matrix[row, col] = cellValue;

            if (!CheckForEmptyCell(matrix, row, col))
            {
                cellValue++;
                break;
            } // prekusvame ako sme se zadunili

            bool isRowOutOfMatrix = row + directionX >= n || row + directionX < 0;
            bool isColOutOfMatrix = col + directionY >= n || col + directionY < 0;
            //bool isCellEmpty = matrix[row + directionX, col + directionY] != 0;
            if (isRowOutOfMatrix || isColOutOfMatrix ||
                matrix[row + directionX, col + directionY] != 0)
            {
                while ((isRowOutOfMatrix || isColOutOfMatrix || matrix[row + directionX, col + directionY] != 0))
                {
                    ChangeDirection(ref directionX, ref directionY);
                    isRowOutOfMatrix = row + directionX >= n || row + directionX < 0;
                    isColOutOfMatrix = col + directionY >= n || col + directionY < 0;
                }
            }

            row += directionX; col += directionY; cellValue++;
        }
    }

    private static void PrintToConsole(int[,] matrix)
    {
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}

