namespace _05.CombinationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class CombinationsWithoutRepetition
    {
        private static string[] elements;
        private static string[] combinations;

        public static void Main()
        {
            elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            combinations = new string[k];
            GetCombinations(k);
        }

        private static void GetCombinations(int k, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    combinations[index] = elements[i];
                    GetCombinations(k, index + 1, i + 1);
                }
            }
        }
    }
}