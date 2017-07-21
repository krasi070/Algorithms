namespace _04.VariationsWithRepetition
{
    using System;
    using System.Linq;

    public class VariationsWitRepetition
    {
        private static string[] elements;
        private static string[] variations;

        public static void Main()
        {
            elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            variations = new string[k];
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
                    variations[index] = elements[i];
                    GetVariations(k, index + 1);
                }
            }
        }
    }
}