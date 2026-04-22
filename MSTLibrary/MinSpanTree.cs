using GraphLibrary;

namespace MSTLibrary
{
    public static class MinSpanTree
    {
        #region Helper Methods

        /// <summary>
        /// Helper method that checks if an edge is present in a list.
        /// Time Complexity is O(n) as it iterates over the list until it finds the edge if it's present.
        /// Space Complexity is O(1) as it only makes comparisons.
        /// </summary>
        /// <param name="edges">The list of edges to search through</param>
        /// <param name="compare">The edge being searched for</param>
        /// <returns>True if the edge is present and false if not</returns>
        private static bool ContainsEdge(this List<Edge> edges, Edge compare)
        {
            foreach (Edge edge in edges)
            {
                if (edge.Equals(compare)) return true;
            }
            return false;
        }

        /// <summary>
        /// Helper method that checks if a node is present in a Graph.
        /// Time Complexity is O(n) as it iterates over the Graph until it finds the node if it's present.
        /// Space Complexity is O(1) as it only makes comparisons.
        /// </summary>
        /// <param name="graph">The Graph to search through</param>
        /// <param name="compare">The Node being searched for</param>
        /// <returns>True if the Node is present and false if not</returns>
        private static bool ContainsNode(this Graph graph, Node_G compare)
        {
            foreach (Node_G node in graph.Nodes)
            {
                if (node.Equals(compare)) return true;
            }
            return false;
        }

        /// <summary>
        /// A helper method that sorts the Nodes in the Graph from least to greatest value.
        /// Time Complexity is O(n) as the amount of iterations needed is dependent on the amount of nodes present, and the amount of iterations per while loop is decreasing.
        /// Space Complexity is O(n) as a temporary node is created each while loop.
        /// </summary>
        /// <param name="graph">The graph being sorted</param>
        private static void Sort(this Graph graph)
        {
            int currentLowestIndex = 0;
            int nodesVisited = 0;

            while (nodesVisited < graph.Nodes.Count)
            {
                for (int i = nodesVisited; i < graph.Nodes.Count; i++)
                {
                    currentLowestIndex = (char.Parse(graph.Nodes[currentLowestIndex].Data) < char.Parse(graph.Nodes[i].Data)) ? currentLowestIndex : i;
                }

                Node_G storeNode = graph.Nodes[nodesVisited];
                graph.Nodes[nodesVisited] = graph.Nodes[currentLowestIndex];
                graph.Nodes[currentLowestIndex] = storeNode;

                nodesVisited++;
                currentLowestIndex = nodesVisited;
            }


        }

        /// <summary>
        /// A helper method that sorts a list of Edges from least to greatest weights.
        /// Time Complexity is O(n) as the method loops until the size of the list.
        /// Space Complexity is O(n) as a temporary node is created on most iterations.
        /// </summary>
        /// <param name="edges">The edges being sorted</param>
        private static void SortEdgesByWeight(List<Edge> edges)
        {
            int currentSize = 1;
            while (currentSize < edges.Count)
            {
                if (edges[currentSize].Weight < edges[currentSize - 1].Weight)
                {
                    Edge stored = edges[currentSize - 1];
                    edges[currentSize - 1] = edges[currentSize];
                    edges[currentSize] = stored;
                }
                currentSize++;
            }
        }

        /// <summary>
        /// A helper method that sorts the Edges in the Node from least to greatest value.
        /// Time Complexity is O(n) as the amount of iterations needed is dependent on the amount of edges present, and the amount of iterations per while loop is decreasing.
        /// Space Complexity is O(n) as a temporary edge is created each while loop.
        /// </summary>
        /// <param name="edges">The edges being sorted</param>
        private static void SortEdgesByData(this List<Edge> edges)
        {
            int currentLowestIndex = 0;
            int edgesVisited = 0;

            while (edgesVisited < edges.Count)
            {
                for (int i = edgesVisited; i < edges.Count; i++)
                {
                    currentLowestIndex = (char.Parse(edges[currentLowestIndex].End.Data) < char.Parse(edges[i].End.Data)) ? currentLowestIndex : i;
                }

                Edge storeEdge = edges[edgesVisited];
                edges[edgesVisited] = edges[currentLowestIndex];
                edges[currentLowestIndex] = storeEdge;

                edgesVisited++;
                currentLowestIndex = edgesVisited;
            }

        }

        /// <summary>
        /// Helper method that determines if an Edge to the comparison Node would create a cycle.
        /// Time Complexity is O(n^2) as it iterates per Edge of the given Node at the index to check for a cycle.
        /// Space Complexity is O(1) as there's only comparison checks.
        /// </summary>
        /// <param name="graph">The Graph with the nodes ot check</param>
        /// <param name="index">The index of the Node who's Edges are being checked</param>
        /// <param name="compare">The Node being checked for within in the Edges to determine a cycle.</param>
        /// <returns>True is a cycle is found and false if not</returns>
        private static bool FindCycle(this Graph graph, int index, Node_G compare)
        {
            //if there is a cycle, the end node will have an edge to another node with and end of the start

            foreach (Edge edge in graph.Nodes[index].Edges)
            {
                for (int i = 0; i < edge.End.Edges.Count; i++)
                {
                    if (edge.End.Edges[i].End.Equals(compare)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Helper method
        /// Time Complexity is O(n^3) unfortunately, as for every Node, every Edge it contains needs to be checked to see if the current Edge list already contains it. I do not know how to optimize this further.
        /// Space Complexity is O(n) as the edge to check is created every iteration of the Edges of the current Node.
        /// </summary>
        /// <param name="graph">The Graph to convert into a List of Edges</param>
        /// <returns>The List of Edges created from the Graph</returns>
        public static List<Edge> GraphToEdges(this Graph graph)
        {
            List<Edge> edges = new List<Edge>();
            //Iterate through the graph
            for (int i = 0; i <= graph.Nodes.Count; i++)
            {
                //Separate the edges from each node
                if (i < graph.Nodes.Count)
                {
                    if (graph.Nodes[i].Edges.Count == 0) return null;

                    for (int j = 0; j < graph.Nodes[i].Edges.Count; j++)
                    {
                        //Handle duplicates => if the start/end combo is already in the current list, skip it
                        //check the reverse order
                        Edge checkEdge = new Edge(graph.Nodes[i].Edges[j].Weight, graph.Nodes[i].Edges[j].End, graph.Nodes[i].Edges[j].Start);
                        if (edges.ContainsEdge(checkEdge)) continue;
                        else edges.Add(graph.Nodes[i].Edges[j]);
                    }
                }
                //Order them from least to greatest by weights
                SortEdgesByWeight(edges);
            }
            return edges;
        }
        #endregion

        /// <summary>
        /// An algorithm for calculating the minimum spanning tree (MST) of a given Graph's edges. 
        /// It uses the weights of the edges and the respective nodes to determine adding the edge to the tree.
        /// Time Complexity is O(n^4), as worst case is the cycle finding algorithm if two Nodes already exist in the MST.
        /// Space Complexity is O(n) as new Nodes are created each iteration.
        /// </summary>
        /// <param name="edges">The edges to build the MST from, in order of least to greatest weights</param>
        /// <returns>The MST of the given edges</returns>
        public static Graph KurskalsAlgo(this List<Edge> edges)
        {
            //Variables
            Graph MST = new Graph();

            if (edges == null) return null;

            Node_G startNode;
            Node_G endNode;

            int startIndex = 0;
            int endIndex = 0;

            //Start building the graph from the edges list
            for (int i = 0; i < edges.Count; i++)
            {
                startNode = new Node_G(edges[i].Start.Data);
                endNode = new Node_G(edges[i].End.Data);

                startIndex = MST.FindNode(MST.Nodes, edges[i].Start.Data);
                endIndex = MST.FindNode(MST.Nodes, edges[i].End.Data);

                //check to see if both the start and end are in the tree
                //if so => check to see if adding an edge creates a cycle
                if (MST.ContainsNode(edges[i].Start) && MST.ContainsNode(edges[i].End))
                {

                    if (MST.FindCycle(startIndex, edges[i].End) || MST.FindCycle(endIndex, edges[i].Start)) continue;

                    MST.Nodes[startIndex].Edges.Add(new Edge(edges[i].Weight, edges[i].Start, edges[i].End));
                    MST.Nodes[endIndex].Edges.Add(new Edge(edges[i].Weight, edges[i].End, edges[i].Start));
                }


                //if not => add the edge to the tree
                else
                {
                    //just contains start
                    if (MST.ContainsNode(edges[i].Start))
                    {
                        MST.Nodes.Add(endNode);

                        MST.Nodes[startIndex].Edges.Add(new Edge(edges[i].Weight, MST.Nodes[startIndex], MST.Nodes[MST.Nodes.Count - 1]));
                        MST.Nodes[MST.Nodes.Count - 1].Edges.Add(new Edge(edges[i].Weight, MST.Nodes[MST.Nodes.Count - 1], MST.Nodes[startIndex]));
                    }
                    //just contains end
                    else if (MST.ContainsNode(edges[i].End))
                    {
                        MST.Nodes.Add(startNode);

                        MST.Nodes[endIndex].Edges.Add(new Edge(edges[i].Weight, MST.Nodes[endIndex], MST.Nodes[MST.Nodes.Count - 1]));
                        MST.Nodes[MST.Nodes.Count - 1].Edges.Add(new Edge(edges[i].Weight, MST.Nodes[MST.Nodes.Count - 1], MST.Nodes[endIndex]));

                    }
                    //neither is added
                    else
                    {
                        MST.Nodes.Add(startNode);
                        MST.Nodes.Add(endNode);

                        //start node edge
                        MST.Nodes[MST.Nodes.Count - 2].Edges.Add(new Edge(edges[i].Weight, MST.Nodes[MST.Nodes.Count - 2], MST.Nodes[MST.Nodes.Count - 1]));
                        //end node edge
                        MST.Nodes[MST.Nodes.Count - 1].Edges.Add(new Edge(edges[i].Weight, MST.Nodes[MST.Nodes.Count - 1], MST.Nodes[MST.Nodes.Count - 2]));
                    }
                }

            }
            //Alphabetize everything god im in hell 
            MST.Sort();

            foreach (Node_G node in MST.Nodes)
            {
                node.Edges.SortEdgesByData();
            }

            //return the graph built from the edges
            return MST;
        }

        /// <summary>
        /// Method that sums up the weights of all the edges in the graph. 
        /// Time Complexity is O(n^3) as the highest complexity is the GraphToEdges method.
        /// Space Complexity is O(1) since variables are only updated. 
        /// </summary>
        /// <param name="graph">The Graph to get the total weight from</param>
        /// <returns>The total weight of the Graph</returns>
        public static int GetTotalWeights(this Graph graph)
        {
            if (graph == null) return 0;

            List<Edge> edges = graph.GraphToEdges();
            int total = 0;

            for (int i = 0; i < edges.Count; i++)
            {
                total += edges[i].Weight;
            }

            return total;
        }
        /// <summary>
        /// Method that sums up the weights of a specified path in the Graph. 
        /// Time Complexity is O(n^3) as the highest complexity is the GraphToEdges method.
        /// Space Complexity is O(1) since variables are only updated. 
        /// </summary>
        /// <param name="graph">The Graph to get the total weight from</param>
        /// <param name="solution">The array of the Node traversal from start to end</param>
        /// <returns>The total weight of the path</returns>
        public static int GetTotalWeights(this Graph graph, string[] solution)
        {
            if (solution.Length == 0 || graph == null) return 0;

            List<Edge> edges = graph.GraphToEdges();
            int total = 0;

            for (int i = 0; i < solution.Length - 1; i++)
            {
                total += graph.FindWeight(edges, solution[i], solution[i + 1]);
            }

            return total;
        }
    }
}
