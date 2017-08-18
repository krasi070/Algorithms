namespace _03.Lumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lumber
    {
        private static bool[] visited;
        private static int[] subGraph;
        private static int count = 0;

        public static void Main()
        {
            int[] inputArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberOfLogs = inputArgs[0];
            visited = new bool[numberOfLogs + 1];
            subGraph = new int[numberOfLogs + 1];
            int numberOfQueries = inputArgs[1];

            Log[] logs = new Log[numberOfLogs + 1];
            List<int>[] graph = new List<int>[numberOfLogs + 1];
            for (int i = 1; i <= numberOfLogs; i++)
            {
                int[] logArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Log newLog = new Log(logArgs[0], logArgs[1], logArgs[2], logArgs[3]);
                logs[i] = newLog;
                graph[i] = new List<int>();
                for (int j = 1;  j < i;  j++)
                {
                    if (newLog.Intersects(logs[j]))
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            for (int i = 1; i <= numberOfLogs; i++)
            {
                if (!visited[i])
                {
                    DFS(i, graph);
                    count++;
                }
            }

            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] queryArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int from = queryArgs[0];
                int to = queryArgs[1];

                Console.WriteLine(subGraph[from] == subGraph[to] ? "YES" : "NO");
            }
        }

        private static void DFS(int vertex, List<int>[] graph)
        {
            visited[vertex] = true;
            subGraph[vertex] = count;
            foreach (var child in graph[vertex])
            {
                if (!visited[child])
                {
                    DFS(child, graph);
                }
            }
        }
    }
}