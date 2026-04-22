using GraphLibrary;

namespace DijkstraLibrary
{
    /// <summary>
    /// A class that is used as a row of data.
    /// The row contains the parent node, if it's visited, its distance to the previous, and its previous if present.
    /// </summary>
    public class Row_DKA
    {
        public Node_G Parent { get; set; }
        public bool Visited { get; set; } = false;
        public int Distance { get; set; }
        public Node_G? Previous { get; set; }

        public Row_DKA(Node_G parent, int distance)
        {
            this.Parent = parent;
            this.Distance = distance;
            this.Visited = false;
            this.Previous = null;
        }
    }
}
