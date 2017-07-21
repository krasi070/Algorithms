namespace _02.PermutationsWithRepetition
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PermutationsWithRepetition
    {
        private static string[] elements;

        public static void Main()
        {
            elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            GetPermutations();
        }

        public static void GetPermutations(int index = 0)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                HashSet<string> swapped = new HashSet<string>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        GetPermutations(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int i, int j)
        {
            string temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}