using System.Collections.Generic;

public static class DijkstraWithoutQueue
{
    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
    {
        int[] path = new int[graph.GetLength(0)];
        int[] prev = new int[graph.GetLength(0)];
        bool[] used = new bool[graph.GetLength(0)];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = int.MaxValue;
            prev[i] = -1;
        }

        path[sourceNode] = 0;
        while (true)
        {
            int minPath = int.MaxValue;
            int minNode = 0;
            for (int node = 0; node < path.Length; node++)
            {
                if (!used[node] && path[node] < minPath)
                {
                    minPath = path[node];
                    minNode = node;
                }
            }

            if (minPath == int.MaxValue)
            {
                break;
            }

            used[minNode] = true;

            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[minNode, i] != 0)
                {
                    if (path[i] > path[minNode] + graph[minNode, i])
                    {
                        path[i] = path[minNode] + graph[minNode, i];
                        prev[i] = minNode;
                    }
                }
            }
        }

        if (destinationNode != sourceNode && prev[destinationNode] == -1)
        {
            return null;
        }

        List<int> result = new List<int>();
        int currNode = destinationNode;
        while (currNode != -1)
        {
            result.Add(currNode);
            currNode = prev[currNode];
        }

        result.Reverse();

        return result; 
    }
}