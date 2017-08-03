namespace _02.LongestCommonSubsequence
{
    using System;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            string firstStr = Console.ReadLine();
            string secondStr = Console.ReadLine();

            Console.WriteLine(GetLengthOfLongestCommonSubsequence(firstStr, secondStr));
        }

        private static int GetLengthOfLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int[,] matrix = new int[firstStr.Length + 1, secondStr.Length + 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    int left = matrix[i, j - 1];
                    int up = matrix[i - 1, j];
                    matrix[i, j] = Math.Max(up, left);
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        matrix[i, j] = Math.Max(matrix[i, j], matrix[i - 1, j - 1] + 1);
                    }
                }
            }

            return matrix[firstStr.Length, secondStr.Length];
        }
    }
}