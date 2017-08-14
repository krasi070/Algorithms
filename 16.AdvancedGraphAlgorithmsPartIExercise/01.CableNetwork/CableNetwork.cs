namespace _01.CableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CableNetwork
    {
        private static bool[] connected;

        public static void Main()
        {
            int budget = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            var graph = ReadGraph();

            int budgetUsed = CalculateBudgetUsed(graph, budget);
            Console.WriteLine($"Budget used: {budgetUsed}");
        }

        private static int CalculateBudgetUsed(List<int[]> graph, int budget)
        {
            // Order by cost
            int budgetUsed = 0;
            graph = graph.OrderBy(e => e[2]).ToList();
            foreach (var edge in graph)
            {
                if (budgetUsed + edge[2] > budget)
                {
                    break;
                }

                if (connected[edge[0]] && !connected[edge[1]])
                {
                    connected[edge[1]] = true;
                    budgetUsed += edge[2];
                }
                else if (connected[edge[1]] && !connected[edge[0]])
                {
                    connected[edge[0]] = true;
                    budgetUsed += edge[2];
                }
            }

            return budgetUsed;
        }

        private static List<int[]> ReadGraph()
        {
            int numberofNodes = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int numberOfEdges = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            connected = new bool[numberofNodes];
            List<int[]> graph = new List<int[]>();
    
            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(args[0]);
                int endNode = int.Parse(args[1]);
                int cost = int.Parse(args[2]);

                if (args.Length > 3)
                {
                    connected[startNode] = true;
                    connected[endNode] = true;
                }

                graph.Add(new int[3]);
                graph[i][0] = startNode;
                graph[i][1] = endNode;
                graph[i][2] = cost;
            }

            return graph;
        }
    }
}