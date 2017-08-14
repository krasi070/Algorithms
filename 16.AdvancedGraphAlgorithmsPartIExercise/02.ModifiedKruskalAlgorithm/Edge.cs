namespace _02.ModifiedKruskalAlgorithm
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public Edge(int start, int end, int weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }

        public int Start { get; set; }

        public int End { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightComapre = this.Weight.CompareTo(other.Weight);
            if (weightComapre == 0)
            {
                int startCompare = this.Start.CompareTo(other.Start);
                if (startCompare == 0)
                {
                    return this.End.CompareTo(other.End);
                }

                return startCompare;
            }

            return weightComapre;
        }
    }
}