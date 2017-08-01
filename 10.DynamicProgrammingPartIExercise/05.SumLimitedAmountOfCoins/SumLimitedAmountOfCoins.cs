namespace _05.SumLimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumLimitedAmountOfCoins
    {
        private static List<int> used = new List<int>();
        private static HashSet<string> combinations = new HashSet<string>();

        public static void Main()
        {
            int[] coins = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sum = int.Parse(Console.ReadLine());

            CalculateNumberOfCombinations(coins, sum);
            Console.WriteLine(combinations.Count);
        }

        private static void CalculateNumberOfCombinations(int[] coins, int sum, int index = 0, int currSum = 0)
        {
            if (sum == currSum)
            {
                string combination = string.Join("x", used);
                if (!combinations.Contains(combination))
                {
                    combinations.Add(combination);
                }

                return;
            }
            else if (currSum > sum)
            {
                return;
            }

            for (int i = index; i < coins.Length; i++)
            {
                currSum += coins[i];
                used.Add(coins[i]);
                CalculateNumberOfCombinations(coins, sum, i + 1, currSum);
                currSum -= coins[i];
                used.Remove(coins[i]);
            }
        }
    }
}