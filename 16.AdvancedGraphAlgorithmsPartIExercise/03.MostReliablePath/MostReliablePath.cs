namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostReliablePath
    {
        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int[] pathArgs = Console.ReadLine()
                .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(int.Parse)
                .ToArray();
            int startNode = pathArgs[0];
            int endNode = pathArgs[1];
            int numberOfEdges = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            List<KeyValuePair<int, int>>[] graph = ReadGraph(numberOfNodes, numberOfEdges);

            List<double[]> mostReliablePath = GetMostReliablePath(graph, startNode, endNode);
            double reliability = mostReliablePath[mostReliablePath.Count - 1][1];
            Console.WriteLine($"Most reliable path reliability: {reliability:F2}%");
            Console.WriteLine(string.Join(" -> ", mostReliablePath.Select(n => n[0])));
        }

        private static List<double[]> GetMostReliablePath(List<KeyValuePair<int, int>>[] graph, int startNode, int endNode)
        {
            double[] reliability = new double[graph.Length];
            int[] previous = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                reliability[i] = 0;
                previous[i] = -1;
            }

            reliability[startNode] = 100;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            while (queue.Count > 0)
            {
                int currNode = queue.Dequeue();
                foreach (var node in graph[currNode])
                {
                    double newValue = reliability[currNode] * node.Value / 100;
                    if (reliability[node.Key] < newValue)
                    {
                        reliability[node.Key] = newValue;
                        previous[node.Key] = currNode;
                        queue.Enqueue(node.Key);
                    }
                }
            }

            List<double[]> result = new List<double[]>();
            int index = endNode;
            while (index != -1)
            {
                result.Add(new double[] { index, reliability[index] });
                index = previous[index];
            }

            result.Reverse();

            return result;
        }

        private static List<KeyValuePair<int, int>>[] ReadGraph(int numberOfNodes, int numberOfEdges)
        {
            List<KeyValuePair<int, int>>[] graph = new List<KeyValuePair<int, int>>[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                graph[i] = new List<KeyValuePair<int, int>>();
            }

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] args = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int from = args[0];
                int to = args[1];
                int reliability = args[2];
                graph[from].Add(new KeyValuePair<int, int>(to, reliability));
                graph[to].Add(new KeyValuePair<int, int>(from, reliability));
            }

            return graph;
        }
    }
}