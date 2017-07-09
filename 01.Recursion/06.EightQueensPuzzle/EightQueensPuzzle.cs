namespace _06.EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class EightQueensPuzzle
    {
        private static bool[,] board = new bool[8, 8];
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedRightToLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedLeftToRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            GenerateSolutions();
        }

        private static void GenerateSolutions(int currRow = 0)
        {
            if (currRow == 8)
            {
                PrintBoard();
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (CanPlaceQueen(currRow, i))
                    {
                        Mark(currRow, i);
                        GenerateSolutions(currRow + 1);
                        Unmark(currRow, i);
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                !attackedCols.Contains(col) &&
                !attackedRightToLeftDiagonals.Contains(row + col) &&
                !attackedLeftToRightDiagonals.Contains(row - col);
        }

        private static void Mark(int row, int col)
        {
            board[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedRightToLeftDiagonals.Add(row + col);
            attackedLeftToRightDiagonals.Add(row - col);
        }

        private static void Unmark(int row, int col)
        {
            board[row, col] = false;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedRightToLeftDiagonals.Remove(row + col);
            attackedLeftToRightDiagonals.Remove(row - col);
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}