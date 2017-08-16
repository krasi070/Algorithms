using System.Collections.Generic;

public class StronglyConnectedComponents
{
    private static int size;
    private static bool[] visited;
    private static List<int>[] graph;
    private static List<int>[] reverseGraph;
    private static List<List<int>> stronglyConnectedComponents;
    private static Stack<int> stack = new Stack<int>();

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        stronglyConnectedComponents = new List<List<int>>();
        graph = targetGraph;
        size = graph.Length;
        visited = new bool[size];
        BuildReverseGraph();

        for (int node = 0; node < size; node++)
        {
            if (!visited[node])
            {
                DFS(node);
            }
        }

        visited = new bool[size];
        while (stack.Count > 0)
        {
            int node = stack.Pop();
            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDFS(node);
            }
        }

        return stronglyConnectedComponents;
    }

    private static void BuildReverseGraph()
    {
        reverseGraph = new List<int>[size];
        for (int node = 0; node < size; node++)
        {
            reverseGraph[node] = new List<int>();
        }

        for (int node = 0; node < size; node++)
        {
            foreach (var childNode in graph[node])
            {
                reverseGraph[childNode].Add(node);
            }
        }
    }

    private static void ReverseDFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            stronglyConnectedComponents[stronglyConnectedComponents.Count - 1].Add(node);
            foreach (var child in reverseGraph[node])
            {
                ReverseDFS(child);
            }
        }
    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }

            stack.Push(node);
        }
    }
}