
namespace GraphLibrary
{
    /// <summary>
    /// A class representing a graph edge. It has a start node, an end node, and the weight between them.
    /// </summary>
    public class Edge
    {
        public Node_G Start {  get; set; }
        public Node_G End { get; set; }
        private int weight;
        public int Weight { 
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }
                weight = value;
            }
        }

        public Edge(int weight, Node_G start, Node_G end)
        {
            this.Weight = weight;
            this.Start = start;
            this.End = end;
        }

        public override bool Equals(object? obj)
        {
            return obj is Edge other && Start.Equals(other.Start) && End.Equals(other.End) && Weight.Equals(other.Weight);
        }
    }
}
