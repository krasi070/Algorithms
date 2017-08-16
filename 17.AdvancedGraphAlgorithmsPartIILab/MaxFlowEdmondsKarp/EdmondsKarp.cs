using System.Collections.Generic;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parent;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parent = new int[graph.Length];
        for (int node = 0; node < parent.Length; node++)
        {
            parent[node] = -1;
        }

        int maxFlow = 0;
        int start = 0;
        int end = graph.Length - 1;

        while (BreadthFirstSearch(start, end))
        {
            int pathFlow = int.MaxValue;
            int currNode = end;
            while (currNode != start)
            {
                int previousNode = parent[currNode];
                if (pathFlow > graph[previousNode][currNode])
                {
                    pathFlow = graph[previousNode][currNode];
                }

                currNode = previousNode;
            }

            maxFlow += pathFlow;
            currNode = end;
            while (currNode != start)
            {
                int previousNode = parent[currNode];
                graph[previousNode][currNode] -= pathFlow;
                graph[currNode][previousNode] += pathFlow;
                currNode = previousNode;
            }
        }

        return maxFlow;
    }

    private static bool BreadthFirstSearch(int start, int end)
    {
        bool[] visited = new bool[graph.Length];

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            visited[node] = true;
            for (int child = 0; child < graph[node].Length; child++)
            {
                if (graph[node][child] > 0 && !visited[child])
                {
                    parent[child] = node;
                    queue.Enqueue(child);
                }
            }
        }

        return visited[end];
    }
}
