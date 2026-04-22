namespace GraphLibrary
{
    /// <summary>
    /// A class representing a graph. It will create a list of nodes using an adjacency list when instantiated.
    /// </summary>
    public class Graph
    {
        public List<Node_G> Nodes { get; set; } = new List<Node_G>();

        /// <summary>
        /// Helper method that will find the index of the node given a string.
        /// Time Complexity is O(n) as it iterates through each node.
        /// Space Complexity is O(1) as variables are updated.
        /// </summary>
        /// <param name="nodes">The list of Nodes to search through</param>
        /// <param name="search">The string data the Node being searched for contains</param>
        /// <returns>The index of the searched Node in the list, or -1 if not found</returns>
        public int FindNode(List<Node_G> nodes, string search)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Data.Equals(search)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Helper method overload that will find the index of the node given a character.
        /// Time Complexity is O(n) as it iterates through each Node.
        /// Space Complexity is O(1) as variables are updated.
        /// </summary>
        /// <param name="nodes">The list of Nodes to search through</param>
        /// <param name="search">The character data the Node being searched for contains</param>
        /// <returns>The index of the searched Node in the list, or -1 if not found</returns>
        public int FindNode(List<Node_G> nodes, char search)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Data.Equals(search.ToString())) return i;
            }
            return -1;
        }

        /// <summary>
        /// Helper method that finds the Weight of an Edge given it's Nodes' Data.
        /// Time Complexity is O(n) as it iterates through each Edge.
        /// Space Complexity is O(1) as only comparisons are made.
        /// </summary>
        /// <param name="edges">The Edges to search through for the specified Edge</param>
        /// <param name="start">The Edge's Start Node Data</param>
        /// <param name="end">The Edge's End Node Data</param>
        /// <returns>The Edge's Weight, or 0 is not present</returns>
        public int FindWeight(List<Edge> edges, string start, string end)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Start.Data.Equals(start) && edges[i].End.Data.Equals(end)) return edges[i].Weight;
            }
            return 0;
        }

        /// <summary>
        /// Constructor for the Graph, which takes in an adjacency list and parses it into a list of nodes.
        /// Time Complexity is O(n^2) as it iterates through the entire adjacency list array and has to iterate through the comma list the indexes contain.
        /// Space Complexity is (O)n as new nodes and edges are being created for the adjacency list, which depends on it's size.
        /// </summary>
        /// <param name="adjacencyList">The adjacency list in a string array format. 
        /// The first index should be all the node labels, which is stored in Data, formatted like "A,B,C..."
        /// The rest should be the adjacencies in the format "Parent,Adjacent:Weight,Adjacent:Weight...", like "A,B:2,C:3..."
        /// </param>
        /// <exception cref="ArgumentNullException">Throws null if the adjacency list is null. You cannot create a graph without a valid adjacency list.</exception>
        public Graph(string[] adjacencyList) 
        {
            if (adjacencyList == null || adjacencyList.Length == 0) throw new ArgumentNullException();
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                //"A,B,C,D,E,F",
                
                if (i == 0)
                {
                    string[] nodes = adjacencyList[i].Split(',');
                    foreach (string data in nodes)
                    {
                        Node_G node = new Node_G(data);
                        Nodes.Add(node);

                    }
                }
                //"A,B:2",
                //"B,A:2,C:4,D:3,F:7",
                //"C,B:4",
                //"D,B:3,E:1,F:4",
                //"E,D:1,F:4",
                //"F,B:7,D:4,E:4"
                else
                {
                    string[] listItems = adjacencyList[i].Split(",");
                    //node is first index
                    //then edge:weight

                    //find node (first index)
                    int updateIndex = FindNode(Nodes, listItems[0]);
                    if (updateIndex != -1)
                    {
                        //update it's edges
                        for (int j = 1; j < listItems.Length; j++) 
                        {
                            //add the node then it's weight
                            int findNode = FindNode(Nodes, listItems[j].First());
                            int weight = int.Parse(listItems[j].Substring(2));

                            Nodes[updateIndex].Edges.Add(new Edge(weight, Nodes[updateIndex], Nodes[findNode]));
                        }
                    }

                }
            }
        }
        public Graph() { }
        public override bool Equals(object? obj)
        {
            if (obj is Graph other)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    if (!Nodes[i].Equals(other.Nodes[i])) return false;
                }
                return true;
            }
            return false;
            
        }
    }
}
