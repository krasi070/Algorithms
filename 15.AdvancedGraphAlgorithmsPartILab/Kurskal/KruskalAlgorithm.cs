using System.Collections.Generic;

public class KruskalAlgorithm
{
    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        int[] parent = new int[numberOfVertices];
        for (int i = 0; i < numberOfVertices; i++)
        {
            parent[i] = i;
        }

        edges.Sort();
        List<Edge> minimumSpanningTree = new List<Edge>();
        foreach (var edge in edges)
        {
            int rootStartNode = FindRoot(edge.StartNode, parent);
            int rootEndNode = FindRoot(edge.EndNode, parent);
            if (rootStartNode != rootEndNode)
            {
                minimumSpanningTree.Add(edge);
                parent[rootEndNode] = rootStartNode;
            }
        }

        return minimumSpanningTree;
    }

    public static int FindRoot(int node, int[] parent)
    {
        int root = node;
        while (parent[root] != root)
        {
            root = parent[root];
        }

        while (root != node)
        {
            parent[node] = root;
            node = parent[node];
        }

        return root;
    }
}