using System.Text;

namespace TreeLibrary
{
    
    public class AVLTree<T> where T : IComparable<T>
    {
        public Node_AVL<T>? Root { get; set; }
        public int Count { get; protected set; } = 0;

        /// <summary>
        /// Adds a new value to the tree, balancing any weighted nodes. 
        /// Time Complexity is O(n) since the highest complexity is the node's Add() method.  
        /// Space Complexity is O(1), since it is always going to add one value no matter the size of the tree
        /// </summary>
        /// <param name="value">The value to add to the tree</param>
        public void Add(T value)
        {
            if (Count == 0)
            {
                Root = new Node_AVL<T>(value);
                Count++;
                return;
            }
            else
            {
                Root?.Add(value);
                if (Root != null) Count++;
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
        /// Space Complexity is O(1) since the Contains() method initializes once and there are only comparisons
        /// </summary>
        /// <param name="value">The value to search for in the tree</param>
        /// <returns>If the tree contains the value (true or false)</returns>
        public bool Contains(T value)
        {
            return (Root != null) ? Root.Contains(value) : false;
        }

        /// <summary>
        /// Removes the specified value from the tree if it is present, or does nothing if the value is not present.
        /// Time Complexity and Space Complexity is O(n) as the highest complexity is the node Remove() method.
        /// </summary>
        /// <param name="value">The value to remove from the tree if present</param>
        public void Remove(T value)
        {
            Root?.Remove(value);
            if (Root != null) Count--;
        }

        /// <summary>
        /// Gets the height from the tree, starting at 0.
        /// Time Complexity is O(n) since it needs to check every node to determine height.
        /// Space Complexity is O(n) since the variables will be re-instantiated every recursive call.
        /// </summary>
        /// <returns>The height of the tree/returns>
        public int Height()
        {
            return (Root != null) ? Root.Height() : 0;
        }


        /// <summary>
        /// Returns the array representation of the tree values using breadth-first search.
        /// Time Complexity is O(n) since it needs to go through each node in the tree.
        /// Space Complexity is O(n) as the variables are initialized every recursive call.
        /// </summary>
        /// <returns>The array of tree values added in order of left to right on each level</returns>
        public T[] ToArray()
        {
            return Root?.ToArray();
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
}
