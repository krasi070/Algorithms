namespace _03.VariationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class VariationsWithoutRepetition
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;

        public static void Main()
        {
            elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            variations = new string[k];
            used = new bool[elements.Length];
            GetVariations(k);
        }

        private static void GetVariations(int k, int index = 0)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        GetVariations(k, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}