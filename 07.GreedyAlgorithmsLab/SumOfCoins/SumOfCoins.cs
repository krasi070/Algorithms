using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();
        int currSum = 0;
        List<int> sortedCoins = coins
            .OrderByDescending(c => c)
            .ToList();
        int index = 0;
        while (currSum < targetSum && index < sortedCoins.Count)
        {
            int currCoin = sortedCoins[index];
            int remainder = targetSum - currSum;
            int numberOfCoins = remainder / currCoin;
            if (numberOfCoins > 0)
            {
                result.Add(currCoin, numberOfCoins);
                currSum += numberOfCoins * currCoin;
            }

            index++;
        }

        if (currSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}