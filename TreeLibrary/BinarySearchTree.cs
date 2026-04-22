using System.Text;

namespace TreeLibrary
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node_BST<T>? Root { get; set; }
        public int Count { get; protected set; } = 0;

        /// <summary>
        /// Adds a new value to the tree, following the rules of a Binary Search Tree. 
        /// Time Complexity is O(log n) since the highest complexity is the Add method.  
        /// Space Complexity is O(1), since it is always going to add one value no matter the size of the tree
        /// </summary>
        /// <param name="value">The value to add to the tree</param>
        public void Add(T value)
        {
            if (Count == 0)
            {
                Root = new Node_BST<T>(value);
                Count++;
                return;
            }
            else
            {
                Root.Add(value);
                Count++;
            }

        }

        /// <summary>
        /// Removes all values from the tree.
        /// Time Complexity is O(1) and Space Complexity is O(1) as it will always reset the Root to null and Count to 0.
        /// </summary>
        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        /// <summary>
        /// Checks the tree for the specified value. It compares the Data to the value and goes to the Left or Right to continue searching.
        /// It goes Left if the value is less than the search value, and goes Right if it's greater than.
        /// Time Complexity is O(log n) since it recursively calls Contains on the Left or Right, cutting searching the whole tree.
        /// </summary>
        /// <param name="value">The value to search for in the tree</param>
        /// <returns>If the tree contains the value (true or false)</returns>
        public bool Contains(T value)
        {
            return Root.Contains(value);
        }

        /// <summary>
        /// Removes the specified value from the tree if it is present, or does nothing if the value is not present.
        /// </summary>
        /// <param name="value">The value to remove from the tree if present</param>
        public void Remove(T value)
        {
            Root?.Remove(value);
            Count--;
        }

        /// <summary>
        /// Gets the height from the tree, starting at 0.
        /// Time Complexity is O(n) since it needs to check every node to determine height.
        /// Space Complexity is O(n) since the variables will be re-instantiated every recursive call.
        /// </summary>
        /// <returns>The height of the tree/returns>
        public int Height()
        {
            return Root.Height();
        }


        /// <summary>
        /// Returns the array representation of the tree values using breadth-first search.
        /// Time Complexity is O(n) since it needs to go through each character in the string.
        /// Space Complexity is O(1) as the variables are initialized once and updated.
        /// </summary>
        /// <param name="inOrder">The breadth-first search string of the tree</param>
        /// <param name="treeCount">The current amount of nodes in the tree</param>
        /// <returns>The array of tree values added in order of Left-Root-Right</returns>
        public T[] ToArray()
        {
            return Root?.ToArray(Root.InOrder(), Count);
        }

        /// <summary>
        /// Returns a string representation of the tree in order of Left-Root-Right.
        /// Time Complexity is O(n) because it goes through all values in the tree.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the tree in a comma separated list in order of Left-Root-Right</returns>
        public string InOrder()
        {
            return Root?.InOrder();
        }

        /// <summary>
        /// Returns a string representation of the tree in order of Root-Left-Right.
        /// Time Complexity is O(n) because it goes through all values in the tree.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the tree in a comma separated list in order of Root-Left-Right</returns>
        public string PreOrder()
        {
            return Root?.PreOrder();
        }

        /// <summary>
        /// Returns a string representation of the tree in order of Left-Right-Root.
        /// Time Complexity is O(n) because it goes through all values in the tree.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the tree in a comma separated list in order of Left-Right-Root</returns>
        public string PostOrder()
        {
            return Root?.PostOrder();
        }
    }

    /// <summary>
    /// Class handling the console output representation of the BST, courtesy of Prof. Beardall (Provided in the assignment)
    /// </summary>
    public static class TreePrinter
    {
        public static void PrintMyTree(AVLTree<int> tree)
        {
            if (tree.Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(tree.Root.Data + " (root)");
            string pointerRight = "'---";
            string pointerLeft = (tree.Root.Right != null) ? "|---" : "'---";
            TraverseNodes(sb, "", pointerLeft, tree.Root.Left, tree.Root.Right != null, true);
            TraverseNodes(sb, "", pointerRight, tree.Root.Right, false, false);
            Console.WriteLine(sb.ToString());
        }
        private static void TraverseNodes(StringBuilder sb, string padding, string pointer, Node_AVL<int> node,
        bool hasRightSibling, bool isLeftNode)
        {
            if (node != null)
            {
                sb.Append("\n");
                sb.Append(padding);
                sb.Append(pointer);
                //This is where we show the data value and if its a left or right child
                sb.Append(node.Data + (isLeftNode ? "(L)" : "(R)"));
                StringBuilder paddingBuilder = new StringBuilder(padding);
                if (hasRightSibling)
                {
                    paddingBuilder.Append("| ");
                }
                else
                {
                    paddingBuilder.Append(" ");
                }
                string paddingForBoth = paddingBuilder.ToString();
                string pointerRight = "'---";
                string pointerLeft = (node.Right != null) ? "|---" : "'---";
                TraverseNodes(sb, paddingForBoth, pointerLeft, node.Left, node.Right != null, true);
                TraverseNodes(sb, paddingForBoth, pointerRight, node.Right, false, false);
            }
        }public static void PrintMyTree(BinarySearchTree<int> tree)
        {
            if (tree.Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(tree.Root.Data + " (root)");
            string pointerRight = "'---";
            string pointerLeft = (tree.Root.Right != null) ? "|---" : "'---";
            TraverseNodes(sb, "", pointerLeft, tree.Root.Left, tree.Root.Right != null, true);
            TraverseNodes(sb, "", pointerRight, tree.Root.Right, false, false);
            Console.WriteLine(sb.ToString());
        }
        private static void TraverseNodes(StringBuilder sb, string padding, string pointer, Node_BST<int> node,
        bool hasRightSibling, bool isLeftNode)
        {
            if (node != null)
            {
                sb.Append("\n");
                sb.Append(padding);
                sb.Append(pointer);
                //This is where we show the data value and if its a left or right child
                sb.Append(node.Data + (isLeftNode ? "(L)" : "(R)"));
                StringBuilder paddingBuilder = new StringBuilder(padding);
                if (hasRightSibling)
                {
                    paddingBuilder.Append("| ");
                }
                else
                {
                    paddingBuilder.Append(" ");
                }
                string paddingForBoth = paddingBuilder.ToString();
                string pointerRight = "'---";
                string pointerLeft = (node.Right != null) ? "|---" : "'---";
                TraverseNodes(sb, paddingForBoth, pointerLeft, node.Left, node.Right != null, true);
                TraverseNodes(sb, paddingForBoth, pointerRight, node.Right, false, false);
            }
        }


    }
}
