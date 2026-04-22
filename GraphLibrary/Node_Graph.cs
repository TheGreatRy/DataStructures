
namespace GraphLibrary
{
    /// <summary>
    /// A class that represents a graph node. Its data is the node label and the edges are its paths to other nodes.
    /// </summary>
    public class Node_G
    {
        public string Data { get; set; }
        public List<Edge> Edges { get; set; } = new List<Edge>();

        public Node_G(string data) => Data = data;

        public override bool Equals(object? obj)
        {
            return obj is Node_G other && Data.Equals(other.Data);
        }
    }
}
