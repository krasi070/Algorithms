namespace _02.ModifiedKruskalAlgorithm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ModifiedKruskalAlgorithm
    {
        private static SortedSet<Edge> edges = new SortedSet<Edge>();
        private static int[] root;

        public static void Main()
        {
            ReadGraph();
            Console.WriteLine($"Minimum spanning forest weight: {GetMinimumSpanningForestWeight()}");
        }

        private static int GetMinimumSpanningForestWeight()
        {
            int forestWeight = 0;
            foreach (var edge in edges)
            {
                if (root[edge.Start] != root[edge.End])
                {
                    forestWeight += edge.Weight;
                    int rootEnd = root[edge.End];
                    for (int i = 0; i < root.Length; i++)
                    {
                        if (root[i] == rootEnd)
                        {
                            root[i] = root[edge.Start];
                        }
                    }
                }
            }

            return forestWeight;
        }

        private static void ReadGraph()
        {    
            int numberOfNodes = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int numberOfEdges = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            root = new int[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                root[i] = i;
            }

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] args = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int from = args[0];
                int to = args[1];
                int weight = args[2];

                edges.Add(new Edge(from, to, weight));
            }
        }
    }
}