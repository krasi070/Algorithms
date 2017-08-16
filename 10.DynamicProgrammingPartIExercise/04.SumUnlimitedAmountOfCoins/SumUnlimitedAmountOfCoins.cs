namespace _04.SumUnlimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumUnlimitedAmountOfCoins
    {
        private static int numberOfCombinations = 0;

        public static void Main()
        {
            int[] coins = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sum = int.Parse(Console.ReadLine());
        
            CalculateNumberOfCombinations(coins, sum);
            Console.WriteLine(numberOfCombinations);
        }

        // Solution from https://github.com/mitkovaelena/Algorithms
        private static void CalculateNumberOfCombinations(int[] coins, int sum, int index = 0, int currSum = 0)
        {
            if (sum == currSum)
            {
                numberOfCombinations++;

                return;
            }
            else if (currSum > sum)
            {
                return;
            }

            for (int i = index; i < coins.Length; i++)
            {
                currSum += coins[i];
                CalculateNumberOfCombinations(coins, sum, i, currSum);
                currSum -= coins[i];
            }
        }
    }
}