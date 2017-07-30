namespace _03.MoveDownRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MoveDownRight
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(rows, cols);

            for (int row = 1; row < rows; row++)
            {
                matrix[row, 0] += matrix[row - 1, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                matrix[0, col] += matrix[0, col - 1];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    matrix[row, col] += Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                }
            }

            List<string> path = new List<string>();
            int currRow = rows - 1;
            int currCol = cols - 1;
            while (!(currRow == 0 && currCol == 0))
            {
                path.Add($"[{currRow}, {currCol}]");
                if (currRow <= 0)
                {
                    currCol--;
                }
                else if (currCol <= 0)
                {
                    currRow--;
                }
                else if (matrix[currRow - 1, currCol] > matrix[currRow, currCol - 1])
                {
                    currRow--;
                }
                else
                {
                    currCol--;
                }
            }

            path.Add("[0, 0]");
            path.Reverse();
            Console.WriteLine(string.Join(" ", path));
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }

            return matrix;
        }
    }
}