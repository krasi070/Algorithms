namespace _05.GeneratingCombinations
{
    using System;
    using System.Linq;

    public class GeneratingCombinations
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            GenerateCombinations(numbers, new int[k]);
        }

        private static void GenerateCombinations(int[] numbers, int[] combinations, int currIndex = 0, int border = 0)
        {
            if (combinations.Length == currIndex)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = border; i < numbers.Length; i++)
                {
                    combinations[currIndex] = numbers[i];
                    GenerateCombinations(numbers, combinations, currIndex + 1, i + 1);
                }
            }
        }
    }
}