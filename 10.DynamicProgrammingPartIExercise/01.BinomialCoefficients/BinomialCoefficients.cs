namespace _01.BinomialCoefficients
{
    using System;

    public class BinomalCoefficients
    {
        private static long[,] memo;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            memo = new long[n + 1, n + 1];
            Console.WriteLine(GetBinomalCoefficient(n, k));
        }

        private static long GetBinomalCoefficient(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (memo[n, k] != 0)
            {
                return memo[n, k];
            }

            if (k == 0 || n == k)
            {
                memo[n, k] = 1;

                return memo[n, k];
            }

            memo[n, k] = GetBinomalCoefficient(n - 1, k - 1) + GetBinomalCoefficient(n - 1, k);
            memo[n, n - k] = memo[n, k];

            return memo[n, k];
        }
    }
}