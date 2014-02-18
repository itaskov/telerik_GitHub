using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mini4ki
{
    public class minite
    {
        public const int MAX_POINTS_NUMBER = 35;

        static void Main()
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

                    Console.Write("Enter command : ");

                    isFirstStart = false;
                }
                else
                {
                    Console.Write("Enter row and column : ");
                }

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
                                ShowBombNumberAroundThePlayerChoice(gameBoard, bombs, row, col);
                                playerPoints++;
                            }
                            if (MAX_POINTS_NUMBER == playerPoints)
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
                    Console.Write("\nYou are dead. Your score is {0} points. " +
                        "Enter your name: ", playerPoints);
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
                    championsPlayes.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    championsPlayes.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    ShowFinalPosition(championsPlayes);

                    gameBoard = CreateGameBoard();
                    bombs = CreateBombs();
                    playerPoints = 0;
                    isPlayerDead = false;
                    isFirstStart = true;
                }
                if (isGameOver)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    ShowGameBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Player to4kii = new Player(imeee, playerPoints);
                    championsPlayes.Add(to4kii);
                    ShowFinalPosition(championsPlayes);
                    gameBoard = CreateGameBoard();
                    bombs = CreateBombs();
                    playerPoints = 0;
                    isGameOver = false;
                    isFirstStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowFinalPosition(List<Player> to4kii)
        {
            Console.WriteLine("\nTo4KI:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, to4kii[i].Name, to4kii[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void ShowBombNumberAroundThePlayerChoice(char[,] gameBoard,
                                                                char[,] bombs, int row, int col)
        {
            char bombNumber = GetBombNumber(bombs, row, col);
            
            bombs[row, col] = bombNumber;
            gameBoard[row, col] = bombNumber;
        }

        private static void ShowGameBoard(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
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
                int col = (bomb / bombCols);
                int row = (bomb % bombCols);

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

        private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = GetBombNumber(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char GetBombNumber(char[,] r, int rr, int rrr)
        {
            int brojkata = 0;
            int reds = r.GetLength(0);
            int kols = r.GetLength(1);

            if (rr - 1 >= 0)
            {
                if (r[rr - 1, rrr] == '*')
                {
                    brojkata++;
                }
            }
            if (rr + 1 < reds)
            {
                if (r[rr + 1, rrr] == '*')
                {
                    brojkata++;
                }
            }
            if (rrr - 1 >= 0)
            {
                if (r[rr, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }
            if (rrr + 1 < kols)
            {
                if (r[rr, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr - 1 >= 0) && (rrr - 1 >= 0))
            {
                if (r[rr - 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr - 1 >= 0) && (rrr + 1 < kols))
            {
                if (r[rr - 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr + 1 < reds) && (rrr - 1 >= 0))
            {
                if (r[rr + 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((rr + 1 < reds) && (rrr + 1 < kols))
            {
                if (r[rr + 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }
            return char.Parse(brojkata.ToString());
        }
    }
}
