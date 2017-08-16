using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parent;
    private static int[] depth;
    private static int[] lowpoint;
    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[graph.Length];
        parent = new int?[graph.Length];
        depth = new int[graph.Length];
        lowpoint = new int[graph.Length];
        articulationPoints = new List<int>();

        FindArticulationPoints(0);

        return articulationPoints;
    }

    private static void FindArticulationPoints(int node, int nodeDepth = 0)
    {
        visited[node] = true;
        depth[node] = nodeDepth;
        lowpoint[node] = nodeDepth;
        int childCount = 0;
        bool isArticulationPoint = false;

        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                parent[child] = node;
                FindArticulationPoints(child, nodeDepth + 1);
                childCount++;

                if (lowpoint[child] >= depth[node])
                {
                    isArticulationPoint = true;
                }

                lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
            }
            else if (child != parent[node])
            {
                lowpoint[node] = Math.Min(lowpoint[node], depth[child]);
            }
        }

        if ((parent[node] != null && isArticulationPoint) ||
            (parent[node] == null && childCount > 1))
        {
            articulationPoints.Add(node);
        }
    }
}
