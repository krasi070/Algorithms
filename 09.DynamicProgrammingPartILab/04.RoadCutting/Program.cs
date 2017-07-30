namespace _04.RoadCutting
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[] bestPrice;
        private static int[] bestCombo;

        public static void Main()
        {
            int[] prices = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            bestPrice = new int[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                bestPrice[i] = -1;
            }

            bestCombo = new int[prices.Length];
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(CutRod(prices, target));
            ReconstructSolution(target);
        }

        private static int CutRod(int[] prices, int target)
        {
            if (bestPrice[target] >= 0)
            {
                return bestPrice[target];
            }

            if (target == 0)
            {
                return 0;
            }

            int best = bestPrice[target];
            for (int i = 1; i <= target; i++)
            {
                best = Math.Max(best, prices[i] + CutRod(prices, target - i));
                if (best > bestPrice[target])
                {
                    bestPrice[target] = best;
                    bestCombo[target] = i;
                }
            }

            return bestPrice[target];
        }

        private static void ReconstructSolution(int n)
        {
            while (n - bestCombo[n] != 0)
            {
                Console.Write(bestCombo[n] + " ");
                n -= bestCombo[n];
            }

            Console.WriteLine(bestCombo[n]);
        }
    }
}