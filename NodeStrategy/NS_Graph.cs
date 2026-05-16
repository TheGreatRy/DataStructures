using NodeStrategy;

namespace NS_Graph
{
    public class NodeStrategy_G : Node<string>
    {
        public List<Edge> Edges { get; set; } = new List<Edge>();

        public NodeStrategy_G(string data) => Data = data;

        public override bool Equals(object? obj)
        {
            return obj is NodeStrategy_G other && Data.Equals(other.Data);
        }
    }
    public class Graph
    {
        public List<NodeStrategy_G> Nodes { get; set; } = new List<NodeStrategy_G>();

        public int FindNode(List<NodeStrategy_G> nodes, string search)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Data.Equals(search)) return i;
            }
            return -1;
        }

        public int FindNode(List<NodeStrategy_G> nodes, char search)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Data.Equals(search.ToString())) return i;
            }
            return -1;
        }

        public int FindWeight(List<Edge> edges, string start, string end)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Start.Data.Equals(start) && edges[i].End.Data.Equals(end)) return edges[i].Weight;
            }
            return 0;
        }

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
                        NodeStrategy_G node = new NodeStrategy_G(data);
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
    public class Edge
    {
        public NodeStrategy_G Start { get; set; }
        public NodeStrategy_G End { get; set; }
        private int weight;
        public int Weight
        {
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

        public Edge(int weight, NodeStrategy_G start, NodeStrategy_G end)
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
