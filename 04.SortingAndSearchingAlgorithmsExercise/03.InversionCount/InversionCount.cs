namespace _03.InversionCount
{
    using System;
    using System.Linq;

    public class InversionCount
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int inversionCount = MergeSort<int>.Sort(arr);
            Console.WriteLine(inversionCount);
        }
    }
}