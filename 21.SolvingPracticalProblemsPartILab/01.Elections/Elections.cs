namespace _01.Elections
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Elections
    {
        private static BigInteger[] possibleSums;

        public static void Main()
        { 
            int numberOfSeats = int.Parse(Console.ReadLine());
            int numberOfParties = int.Parse(Console.ReadLine());
            int[] parties = new int[numberOfParties];
            for (int i = 0; i < numberOfParties; i++)
            {
                parties[i] = int.Parse(Console.ReadLine());
            }

            possibleSums = new BigInteger[parties.Sum() + 1];
            possibleSums[0] = 1;
            Console.WriteLine(GetNumberOfPossibleParliaments(parties, numberOfSeats));
        }

        private static BigInteger GetNumberOfPossibleParliaments(int[] parties, int numberOfSeats)
        {
            for (int i = 0; i < parties.Length; i++)
            {
                for (int j = possibleSums.Length - 1; j >= 0; j--)
                {
                    if (possibleSums[j] > 0)
                    {
                        possibleSums[j + parties[i]] += possibleSums[j];
                    }
                }
            }

            BigInteger count = 0;
            for (int i = numberOfSeats; i < possibleSums.Length; i++)
            {
                count += possibleSums[i];
            }

            return count;
        }
    }
}