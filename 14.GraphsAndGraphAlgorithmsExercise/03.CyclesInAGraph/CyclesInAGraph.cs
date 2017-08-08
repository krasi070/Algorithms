namespace _03.CyclesInAGraph
{
    using System;
    using System.Collections.Generic;

    public class CyclesInAGraph
    {
        private static HashSet<string> visited = new HashSet<string>();

        public static void Main()
        {
            Dictionary<string, List<string>> graph = ReadGraph();
            bool isCyclic = false;
            foreach (var vertex in graph.Keys)
            {
                isCyclic = IsGraphCyclic(graph, vertex);
                break;
            }

            Console.WriteLine("Acyclic: " + (isCyclic ? "No" : "Yes"));
        }

        private static bool IsGraphCyclic(Dictionary<string, List<string>> graph, string startVertex)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startVertex);
            while (queue.Count > 0)
            {
                string currVertex = queue.Dequeue();
                if (visited.Contains(currVertex))
                {
                    return true;
                }

                visited.Add(currVertex);
                foreach (var vertex in graph[currVertex])
                {
                    graph[vertex].Remove(currVertex);
                    queue.Enqueue(vertex);
                }
            }

            return false;
        }

        private static void RemoveVertex(Dictionary<string, List<string>> graph, string vertex)
        {
            graph.Remove(vertex);
            foreach (var v in graph)
            {
                v.Value.Remove(vertex);
            }
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();
            while (line != null && line != string.Empty)
            {
                string[] vertices = line.Split('–');
                if (!graph.ContainsKey(vertices[0]))
                {
                    graph.Add(vertices[0], new List<string>());
                }

                graph[vertices[0]].Add(vertices[1]);

                if (!graph.ContainsKey(vertices[1]))
                {
                    graph.Add(vertices[1], new List<string>());
                }

                graph[vertices[1]].Add(vertices[0]);

                line = Console.ReadLine();
            }

            return graph;
        }
    }
}