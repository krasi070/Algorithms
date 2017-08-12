using System.Collections.Generic;

public static class DijkstraWithPriorityQueue
{
    public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
    {
        int?[] previous = new int?[graph.Count];
        bool[] visited = new bool[graph.Count];
        PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

        sourceNode.DistanceFromStart = 0;
        visited[sourceNode.Id] = true;
        priorityQueue.Enqueue(sourceNode);
        while (priorityQueue.Count > 0)
        {
            Node minNode = priorityQueue.ExtractMin();
            if (minNode.Id == destinationNode.Id)
            {
                break;
            }

            foreach (var edge in graph[minNode])
            {
                if (!visited[edge.Key.Id])
                {
                    priorityQueue.Enqueue(edge.Key);
                    visited[edge.Key.Id] = true;
                }

                double distance = minNode.DistanceFromStart + edge.Value;
                if (distance < edge.Key.DistanceFromStart)
                {
                    edge.Key.DistanceFromStart = distance;
                    previous[edge.Key.Id] = minNode.Id;
                    priorityQueue.DecreaseKey(edge.Key);
                }
            }
        }

        if (double.IsInfinity(destinationNode.DistanceFromStart))
        {
            return null;
        }

        List<int> result = new List<int>();
        int? currId = destinationNode.Id;
        while (currId != null)
        {
            result.Add(currId.Value);
            currId = previous[currId.Value];
        }

        result.Reverse();

        return result;
    }
}