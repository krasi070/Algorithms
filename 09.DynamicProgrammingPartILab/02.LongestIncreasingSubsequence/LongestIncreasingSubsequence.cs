namespace _02.LongestIncreasingSubsequence
{
    using System;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        private static int[] memo;
        private static int[] next;

        public static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            memo = new int[sequence.Length];
            next = new int[sequence.Length];

            for (int i = 0; i < sequence.Length; i++)
            {
                LIS(sequence, i);
            }

            PrintLIS(sequence);
        }

        private static int LIS(int[] sequence, int index = 0)
        {
            if (memo[index] != 0)
            {
                return memo[index];
            }

            int maxLength = 1;
            next[index] = -1;
            for (int i = index + 1; i < sequence.Length; i++)
            {
                if (sequence[index] < sequence[i])
                {
                    if (LIS(sequence, i) >= maxLength)
                    {
                        maxLength = LIS(sequence, i) + 1;
                        next[index] = i;
                    }
                }
            }

            memo[index] = maxLength;

            return maxLength;
        }

        private static void PrintLIS(int[] sequnce)
        {
            int index = 0;
            for (int i = 1; i < sequnce.Length; i++)
            {
                if (memo[index] < memo[i])
                {
                    index = i;
                }
            }

            while (true)
            {
                Console.Write(sequnce[index] + " ");
                if (next[index] == -1)
                {
                    Console.WriteLine();
                    break;
                }

                index = next[index];
            }
        }
    }
}