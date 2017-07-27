namespace _05.EgyptianFractions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class EgyptianFractions
    {
        public static void Main()
        {
            int[] args = Console.ReadLine()
            .Split('/')
            .Select(int.Parse)
            .ToArray();

            if (args[0] > args[1])
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");

                return;
            }

            Console.WriteLine($"{args[0]}/{args[1]} = {string.Join(" + ", GetEgyptianFraction(args[0], args[1]))}");
        }

        // Solution taken from https://github.com/peter-stoyanov/Algorithms
        private static IList<string> GetEgyptianFraction(int p, int q)
        {
            List<string> result = new List<string>();
            int denominator = 2;
            while (p > 0)
            {
                while (p * denominator < q)
                {
                    denominator++;
                }

                p *= denominator;
                p -= q;
                q *= denominator;

                result.Add($"1/{denominator}");
                denominator++;
            }

            return result;
        }
    }
}