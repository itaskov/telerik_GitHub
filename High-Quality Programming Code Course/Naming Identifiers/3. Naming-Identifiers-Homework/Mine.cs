using System;
using System.Collections.Generic;

public class Mine
{
    public const int MaxPoints = 35;

    public static void Main()
    {
        string command = string.Empty;

        char[,] gameBoard = CreateGameBoard();
        char[,] bombs = CreateBombs();

        int playerPoints = 0;

        bool isPlayerDead = false;

        List<Player> championsPlayes = new List<Player>(6);

        int row = 0;
        int col = 0;

        bool isFirstStart = true;
        bool isGameOver = false;

        do
        {
            if (isFirstStart)
            {
                Console.WriteLine("Let play “Mine”. Try to open fiels without mines.\n" +
                "Commands:\n'top' - show position\n'start' - start new game\n'exit' - exit game\n");

                ShowGameBoard(gameBoard);

                isFirstStart = false;
            }

            Console.Write("Enter row and column : ");

            command = Console.ReadLine().Trim();

            if (command.Length >= 3)
            {
                if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                    row <= gameBoard.GetLength(0) &&
                    col <= gameBoard.GetLength(1))
                {
                    command = "turn";
                }
            }

            switch (command)
            {
                case "top":
                    ShowFinalPosition(championsPlayes);
                    break;
                case "start":
                    gameBoard = CreateGameBoard();
                    bombs = CreateBombs();
                    ShowGameBoard(gameBoard);
                    isPlayerDead = false;
                    isFirstStart = false;
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    break;
                case "turn":
                    if (bombs[row, col] != '*')
                    {
                        if (bombs[row, col] == '-')
                        {
                            OpenCell(gameBoard, bombs, row, col);
                            playerPoints++;
                        }

                        if (MaxPoints == playerPoints)
                        {
                            isGameOver = true;
                        }
                        else
                        {
                            ShowGameBoard(gameBoard);
                        }
                    }
                    else
                    {
                        isPlayerDead = true;
                    }

                    break;
                default:
                    Console.WriteLine("\nInvalid command!\n");
                    break;
            }

            if (isPlayerDead)
            {
                ShowGameBoard(bombs);
                Console.Write(
                            "\nYou are dead. Your score is {0} points. " + "Enter your name: ", playerPoints);
                string playerName = Console.ReadLine();
                Player lastPlayer = new Player(playerName, playerPoints);
                if (championsPlayes.Count < 5)
                {
                    championsPlayes.Add(lastPlayer);
                }
                else
                {
                    for (int i = 0; i < championsPlayes.Count; i++)
                    {
                        if (championsPlayes[i].Points < lastPlayer.Points)
                        {
                            championsPlayes.Insert(i, lastPlayer);
                            championsPlayes.RemoveAt(championsPlayes.Count - 1);
                            break;
                        }
                    }
                }

                championsPlayes.Sort((Player first, Player next) => next.Name.CompareTo(first.Name));
                championsPlayes.Sort((Player first, Player next) => next.Points.CompareTo(first.Points));

                ShowFinalPosition(championsPlayes);

                gameBoard = CreateGameBoard();
                bombs = CreateBombs();

                playerPoints = 0;

                isPlayerDead = false;
                isFirstStart = true;
            }

            if (isGameOver)
            {
                Console.WriteLine("\nCongratulation! You opened all 35 cells.");

                ShowGameBoard(bombs);

                Console.WriteLine("Enter your name: ");

                string playerName = Console.ReadLine();

                var player = new Player(playerName, playerPoints);

                championsPlayes.Add(player);

                ShowFinalPosition(championsPlayes);

                gameBoard = CreateGameBoard();
                bombs = CreateBombs();

                playerPoints = 0;

                isGameOver = false;
                isFirstStart = true;
            }
        }
        while (command != "exit");

        Console.WriteLine("Game Mime.");
        Console.WriteLine("Made in Bulgaria!");
        Console.Read();
    }

    private static void ShowFinalPosition(List<Player> playerList)
    {
        Console.WriteLine("\npoints: ");
        if (playerList.Count > 0)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                Console.WriteLine(
                                "{0}. {1} --> {2} cells",
                                i + 1,
                                playerList[i].Name,
                                playerList[i].Points);
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Empty position!\n");
        }
    }

    private static void OpenCell(
                                                            char[,] gameBoard,
                                                            char[,] bombs,
                                                            int row,
                                                            int col)
    {
        char bombNumber = GetBombNumber(bombs, row, col);

        bombs[row, col] = bombNumber;
        gameBoard[row, col] = bombNumber;
    }

    private static void ShowGameBoard(char[,] board)
    {
        int boardRows = board.GetLength(0);
        int boardCols = board.GetLength(1);

        Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("   ---------------------");

        for (int i = 0; i < boardRows; i++)
        {
            Console.Write("{0} | ", i);
            for (int j = 0; j < boardCols; j++)
            {
                Console.Write(string.Format("{0} ", board[i, j]));
            }

            Console.Write("|");
            Console.WriteLine();
        }

        Console.WriteLine("   ---------------------\n");
    }

    private static char[,] CreateGameBoard()
    {
        int boardRows = 5;
        int boardColumns = 10;

        char[,] board = new char[boardRows, boardColumns];

        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardColumns; j++)
            {
                board[i, j] = '?';
            }
        }

        return board;
    }

    private static char[,] CreateBombs()
    {
        int bombRows = 5;
        int bombCols = 10;

        char[,] gameBoard = new char[bombRows, bombCols];

        for (int i = 0; i < bombRows; i++)
        {
            for (int j = 0; j < bombCols; j++)
            {
                gameBoard[i, j] = '-';
            }
        }

        List<int> bombList = new List<int>();

        while (bombList.Count < 15)
        {
            Random random = new Random();

            int bombPosition = random.Next(50);

            if (!bombList.Contains(bombPosition))
            {
                bombList.Add(bombPosition);
            }
        }

        foreach (int bomb in bombList)
        {
            int col = bomb / bombCols;
            int row = bomb % bombCols;

            if (row == 0 && bomb != 0)
            {
                col--;
                row = bombCols;
            }
            else
            {
                row++;
            }

            gameBoard[col, row - 1] = '*';
        }

        return gameBoard;
    }

    private static char GetBombNumber(char[,] bombs, int row, int col)
    {
        int bombNumber = 0;
        int bombRows = bombs.GetLength(0);
        int bombCols = bombs.GetLength(1);

        if (row - 1 >= 0)
        {
            if (bombs[row - 1, col] == '*')
            {
                bombNumber++;
            }
        }

        if (row + 1 < bombRows)
        {
            if (bombs[row + 1, col] == '*')
            {
                bombNumber++;
            }
        }

        if (col - 1 >= 0)
        {
            if (bombs[row, col - 1] == '*')
            {
                bombNumber++;
            }
        }

        if (col + 1 < bombCols)
        {
            if (bombs[row, col + 1] == '*')
            {
                bombNumber++;
            }
        }

        if ((row - 1 >= 0) && (col - 1 >= 0))
        {
            if (bombs[row - 1, col - 1] == '*')
            {
                bombNumber++;
            }
        }

        if ((row - 1 >= 0) && (col + 1 < bombCols))
        {
            if (bombs[row - 1, col + 1] == '*')
            {
                bombNumber++;
            }
        }

        if ((row + 1 < bombRows) && (col - 1 >= 0))
        {
            if (bombs[row + 1, col - 1] == '*')
            {
                bombNumber++;
            }
        }

        if ((row + 1 < bombRows) && (col + 1 < bombCols))
        {
            if (bombs[row + 1, col + 1] == '*')
            {
                bombNumber++;
            }
        }

        return char.Parse(bombNumber.ToString());
    }
}
