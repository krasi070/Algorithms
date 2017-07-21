namespace _01.Sorting
{
    using System;
    using System.Linq;

    public class Sorting
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int curr = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[curr] < arr[j])
                    {
                        int temp = arr[curr];
                        arr[curr] = arr[j];
                        arr[j] = temp;
                        curr--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}