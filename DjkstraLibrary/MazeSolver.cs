using GraphLibrary;

namespace DijkstraLibrary
{
    public class MazeSolver
    {
        private List<Row_DKA> tableDKA = new List<Row_DKA>();

        /// <summary>
        /// Helper method that checks if all nodes in a table are visited. 
        /// Time Complexity is O(n) since we are looping over each row in the table.
        /// Space Complexity is O(1) as it only does comparison checks.
        /// </summary>
        /// <param name="table">The table to check</param>
        /// <returns>True if all nodes are visited but false if 1 or more is not.</returns>
        private bool AllVisited(List<Row_DKA> table)
        {
            foreach (Row_DKA tableRow in tableDKA)
            {
                if (tableRow.Visited == false) return false;
            }
            return true;
        }

        /// <summary>
        /// Helper method that returns the index of the row you want to update in the table, with a given edge to update its end. 
        /// The edge's start is the parent node, so we must update the end to create a path.
        /// Time Complexity is O(n) as we go through each element in the table to determine what row needs to be updated and its index.
        /// Space Complexity is O(1) as variables are initialized once and updated throughout the method.
        /// </summary>
        /// <param name="edge">The edge to search for in the table</param>
        /// <returns>The index of the edge in the table, or -1 if it doesn't exist</returns>
        private int UpdateTableIndex(Edge edge)
        {
            Row_DKA updateTableRow = null;

            //find the row to update if it exists => the edge's end node must match one from the table
            foreach (Row_DKA tableRow in tableDKA)
            {
                if (tableRow.Parent.Data == edge.End.Data) updateTableRow = tableRow;
            }

            //if the edge is in the table
            if (updateTableRow != null)
            {
                //iterate until the row is found and return its index
                for (int i = 0; i < tableDKA.Count; i++)
                {
                    if (tableDKA[i].Equals(updateTableRow)) return i;
                }
            }
            return -1;
        }
        
        /// <summary>
        /// Helper method that returns the index of a row given the node data it contains.
        /// Time Complexity is O(n) as it iterates through the table until the index is found.
        /// Space Complexity is O(1) as the index is initialized once then updated.
        /// </summary>
        /// <param name="data">The node data</param>
        /// <returns>The index of the row that contains the data if it exists, or -1 if it doesn't</returns>
        private int FindTableRowIndex(string data)
        {
            for (int i = 0; i < tableDKA.Count; i++)
            {
                if (tableDKA[i].Parent.Data.Equals(data)) return i;
            }
            return -1;
        }

        /// <summary>
        /// A maze solver method that finds the shortest path from the start node to the end node given its graph. 
        /// The path is added to a string array, with the start node at the first index and the end node at the last.
        /// If there are multiple solutions, it will output the first one. If there are no solutions, it will be null.
        /// Time Complexity is O(n^2) as the method iterates until all the nodes are visited, which also has a nested iteration per cycle.
        /// Space Complexity is O(1) as all variables are initialized once then updated within the method.
        /// </summary>
        /// <param name="graph">The graph created with the maze adjacency list</param>
        /// <param name="start">The start node of the maze</param>
        /// <param name="end">The end node of the maze</param>
        /// <returns>A string array of the nodes in order of the maze solution, or null if there's no solution</returns>
        public string[] SolveMaze(Graph graph, string start, string end)
        {
            //Variables
            List<string> solution = new List<string>();
            int currentLowestIndex = 0;
            int checkForLastNode = 0;
            int distance = 0;
            int sum = 0;

            //Pick a start node
            //create a table where start distance is 0
            //all other nodes => inf
            //all prev nodes => null (in constructor)
            //all nodes visited => false (in constructor)
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                distance = graph.Nodes[i].Data.Equals(start) ? 0 : int.MaxValue;
                Row_DKA row_DKA = new Row_DKA(graph.Nodes[i], distance);

                tableDKA.Add(row_DKA);
            }

            //Start solving
            while (!AllVisited(tableDKA))
            {
                currentLowestIndex = 0;
                checkForLastNode = 0;

                //Pick the node in the table with the lowest distance (iterate until all are visited)
                for (int i = 0; i < tableDKA.Count; i++)
                {
                    //If we are not at the end of the table
                    if (i < tableDKA.Count - 1)
                    {
                        //If the node we are currently on is visited and the last node check is not incremented
                        if (tableDKA[i].Visited == true && checkForLastNode < 1)
                        {
                            //shift the current lowest index to the next index
                            currentLowestIndex = i + 1;
                            continue;
                        }
                        //If the next row's node is not visited
                        else if (tableDKA[i+1].Visited == false)
                        {
                            //update current index based on if the current row's node or the next row's node is lower => we take the lowest
                            currentLowestIndex = (tableDKA[currentLowestIndex].Distance < tableDKA[i + 1].Distance) ? currentLowestIndex : i + 1;
                        }
                        else
                        {
                            //increment last node check
                            //this catches looping if the last node, the only node not visited on the table, has a value greater than it's comparison node
                            checkForLastNode++;
                        }
                    }
                }
                //Mark node with current lowest value visited
                tableDKA[currentLowestIndex].Visited = true;

                //look at ALL edges (iterate)
                foreach (Edge edge in tableDKA[currentLowestIndex].Parent.Edges)
                {
                    //sum up edge distance + current node distance
                    sum = tableDKA[currentLowestIndex].Distance + edge.Weight;
                    
                    //update IF distance > sum
                    if (tableDKA[UpdateTableIndex(edge)].Distance > sum)
                    {
                        //set the edge's end node to the lesser distance and it's previous to the current node's parent
                        tableDKA[UpdateTableIndex(edge)].Distance = sum;
                        tableDKA[UpdateTableIndex(edge)].Previous = tableDKA[currentLowestIndex].Parent;
                    }
                }
            }
            //set current previous to the end node
            Row_DKA currentPrevious = tableDKA[FindTableRowIndex(end)];

            //Check for no solution => if there's no previous at the end no, nothing can reach it
            if (currentPrevious.Previous == null) return null;

            //start at the end and go through the previouses until you reach the start (not inclusive of start)
            while (currentPrevious != null && !currentPrevious.Parent.Data.Equals(start))
            {
                solution.Insert(0, currentPrevious.Parent.Data);
                currentPrevious = tableDKA[FindTableRowIndex(currentPrevious.Previous.Data)];   
            }

            //Insert the start data to the front
            solution.Insert(0, start);

            return solution.ToArray();
        }
    }
}
