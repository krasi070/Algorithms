namespace _03.KnightsTour
{
    using System;

    public class KnightsTour
    {
        private static int[] changeRow = new int[] { 1, -1, 1, -1, 2, 2, -2, -2 };
        private static int[] changeCol = new int[] { 2, 2, -2, -2, 1, -1, 1, -1 };

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            FillMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            int step = 1;
            int row = 0;
            int col = 0;
            int numberOfCells = matrix.GetLength(0) * matrix.GetLength(1);
            while (step <= numberOfCells)
            {
                matrix[row, col] = step;

                int[] nextCell = GetNextCell(matrix, row, col);
                row = nextCell[0];
                col = nextCell[1];

                step++;
            }
        }

        private static int[] GetNextCell(int[,] matrix, int row, int col)
        {
            int minPossibleMoves = 9;
            int[] nextCell = new int[2];
            for (int i = 0; i < changeRow.Length; i++)
            {
                if (IsInBounds(matrix.GetLength(0), row + changeRow[i], col + changeCol[i]) && 
                    matrix[row + changeRow[i], col + changeCol[i]] == 0)
                {
                    int possibleMoves = GetNumberfPossibleMoves(matrix, row + changeRow[i], col + changeCol[i]);
                    if (possibleMoves < minPossibleMoves)
                    {
                        minPossibleMoves = possibleMoves;
                        nextCell[0] = row + changeRow[i];
                        nextCell[1] = col + changeCol[i];
                    }
                }
            }

            return nextCell;
        }

        private static int GetNumberfPossibleMoves(int[,] matrix, int row, int col)
        {
            int numberOfPossibleMoves = 0;
            for (int i = 0; i < changeRow.Length; i++)
            {
                if (IsInBounds(matrix.GetLength(0), row + changeRow[i], col + changeCol[i]) && 
                    matrix[row + changeRow[i], col + changeCol[i]] == 0)
                {
                    numberOfPossibleMoves++;
                }
            }

            return numberOfPossibleMoves;
        }

        private static bool IsInBounds(int n, int row, int col)
        {
            return row >= 0 && row < n &&
                col >= 0 && col < n;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(3, ' ') + " ");
                }

                Console.WriteLine();
            }
        }
    }
}