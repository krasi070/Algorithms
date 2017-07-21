namespace _01.PermutationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class PermutationsWithoutRepetition
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        public static void Main()
        {
            elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            GetPermutations();
        }

        private static void GetPermutations(int index = 0)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        permutations[index] = elements[i];
                        used[i] = true;
                        GetPermutations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}