namespace _02.IterativeCombinationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class IterativeCombinationsWithoutRepetition
    {
        public static void Main()
        {
            string[] elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            PrintCombinations(elements, k);
        }

        private static void PrintCombinations(string[] arr, int k)
        {
            int n = arr.Length;
            CombinationElement[] combinations = new CombinationElement[k];
            int i = 0;
            int j = 0;
            while (true)
            {
                if (j >= k)
                {
                    Console.WriteLine(string.Join<CombinationElement>(" ", combinations));
                    int valToLowerJ = 1;
                    while (k >= valToLowerJ && combinations[k - valToLowerJ].Value == arr[n - valToLowerJ])
                    {
                        valToLowerJ++;
                    }

                    j -= valToLowerJ;
                    if (j < 0)
                    {
                        break;
                    }

                    if (i == n)
                    {
                        i = combinations[j].OriginalIndex + 1;
                    }
                }

                combinations[j] = new CombinationElement(i, arr[i]);
                i++;
                j++;
            }
        }
    }

    public class CombinationElement
    {
        public CombinationElement(int i, string val)
        {
            this.OriginalIndex = i;
            this.Value = val;
        }

        public int OriginalIndex { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }
    }
}