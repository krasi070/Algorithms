namespace _01.Fibonacci
{
    using System;

    public class Fibonacci
    {
        private static long[] memo;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            memo = new long[n + 1];
            memo[0] = 0;
            memo[1] = 1;
            Console.WriteLine(GetNthFibonacci(n));
        }

        private static long GetNthFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = GetNthFibonacci(n - 1) + GetNthFibonacci(n - 2);

            return memo[n];
        }
    }
}