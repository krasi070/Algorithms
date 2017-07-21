namespace _07.NChooseKCount
{
    using System;

    public class NChooseKCount
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(GetNumberOfCombinations(n, k));
        }

        public static long GetNumberOfCombinations(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == n || k == 0)
            {
                return 1;
            }

            return GetNumberOfCombinations(n - 1, k - 1) + GetNumberOfCombinations(n - 1, k);
        }
    }
}