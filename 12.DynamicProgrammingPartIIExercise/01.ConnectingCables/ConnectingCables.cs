namespace _01.ConnectingCables
{
    using System;
    using System.Linq;

    public class ConnectingCables
    {
        public static void Main()
        {
            int[] permutation = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] sortedNumbers = permutation
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine($"Maximum pairs connected: {GetNumberOfMaxPairsConnected(sortedNumbers, permutation)}");
        }

        private static int GetNumberOfMaxPairsConnected(int[] a, int[] b)
        {
            int[,] matrix = new int[a.Length + 1, b.Length + 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    int up = matrix[i - 1, j];
                    int left = matrix[i, j - 1];
                    matrix[i, j] = Math.Max(up, left);
                    if (a[i - 1] == b[j - 1])
                    {
                        matrix[i, j] = Math.Max(matrix[i, j], matrix[i - 1, j - 1] + 1);
                    }
                }
            }

            return matrix[a.Length, b.Length];
        }
    }
}