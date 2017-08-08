namespace _04.Salaries
{
    using System;
    using System.Collections.Generic;

    public class Salaries
    {
        private static long[] salaries;
        private static List<int>[] managerOf;

        public static void Main()
        {
            ReadGraph();
            long sum = 0;
            for (int i = 0; i < salaries.Length; i++)
            {
                sum += CalculateSalary(i);
            }

            Console.WriteLine(sum);
        }

        private static long CalculateSalary(int index = 0)
        {
            if (salaries[index] > 0)
            {
                return salaries[index];
            }

            if (managerOf[index].Count == 0)
            {
                salaries[index] = 1;
            }
            else
            {
                for (int i = 0; i < managerOf[index].Count; i++)
                {
                    salaries[index] += CalculateSalary(managerOf[index][i]);
                }
            }

            return salaries[index];
        }

        private static void ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            salaries = new long[n];
            managerOf = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                managerOf[i] = new List<int>();
                string line = Console.ReadLine().ToLower();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'y')
                    {
                        managerOf[i].Add(j);
                    }
                }
            }
        }
    }
}