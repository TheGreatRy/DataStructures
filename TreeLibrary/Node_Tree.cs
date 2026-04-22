using System.Text;

namespace TreeLibrary
{
    public class Node_BST<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node_BST<T>? Left { get; set; }
        public Node_BST<T>? Right { get; set; }
        public Node_BST(T data) => Data = data;

        /// <summary>
        /// Adds a value to the Left or Right node of the current node. If the value is equal to the current node Data, it will be added to the Left node.
        /// Time Complexity is O(log n) as it recursively calls Add until a null node is found. 
        /// Space Complexity is O(1) as it will only add one new node once the method finds a null node
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {

            //check the left and right of the current node (recursive)
            //if value <= node data, check left
            if (value.CompareTo(Data) <= 0)
            {
                //check to see if left is null
                if (Left == null)
                {
                    Left = new Node_BST<T>(value);
                }
                else
                {
                    Left.Add(value);
                }
            }
            //if value > node data, check right
            else
            {
                //check to see if right is null
                if (Right == null)
                {
                    Right = new Node_BST<T>(value);
                }
                else
                {
                    Right.Add(value);
                }
            }

        }

        /// <summary>
        /// Checks the Node and its children for the specified value. It compares the Data to the value and goes to the Left or Right to continue searching.
        /// It goes Left if the value is less than the search value, and goes Right if it's greater than/
        /// Time Complexity is O(log n) since it recursively calls Contains on the Left or Right, cutting searching the whole tree.
        /// Space Complexity is O(1) as it only make comparisons.
        /// </summary>
        /// <param name="value">The value to search for in the Node</param>
        /// <returns>If the node or its children contains the value (true or false)</returns>
        public bool Contains(T value)
        {
            //check ourselves, left, and right
            //the current node has the value
            if (Data.CompareTo(value) == 0) return true;
            else
            {
                if (value.CompareTo(Data) <= 0)
                {
                    if (Left == null) return false;
                    else return Left.Contains(value);
                }
                else
                {
                    if (Right == null) return false;
                    else return Right.Contains(value);
                }
            }
        }

        /// <summary>
        /// Removes the specified value from the node if it is present, or does nothing if the value is not present.
        /// </summary>
        /// <param name="value">The value to remove from the node if present</param>
        public void Remove(T value)
        {
            //Check to see if the value is contained in the tree before deleting
            if (!Contains(value)) return;

            //store the current Node's Left and Right
            Node_BST<T> leftNode = Left;
            Node_BST<T> rightNode = Right;

            //base case
            if (Data.CompareTo(value) == 0)
            {
                //shift left value if present
                if (leftNode != null)
                {
                    Data = leftNode.Data;
                    if (leftNode.Left != null) Left = leftNode.Left;
                    else Left = null;
                    if (leftNode.Right != null)
                    {
                        Right = leftNode.Right;
                        if (rightNode != null) Right.Right = rightNode;
                    }
                }
            }
            else
            //recursive case
            {
                if (value.CompareTo(Data) <= 0)
                {
                    Left.Remove(value);
                    //edge case => Left has no children
                    if (Left.Left == null && Left.Right == null) Left = null;
                }
                else
                {
                    Right.Remove(value);
                    //edge case => Right has no children
                    if (Right.Left == null && Right.Right == null) Right = null;
                }
            }

        }


        /// <summary>
        /// Gets the height from the current node, starting at 0.
        /// Time Complexity is O(n) since it needs to check every node to determine height.
        /// Space Complexity is O(n) since the variables will be re-instantiated every recursive call.
        /// </summary>
        /// <returns>The height from the current node</returns>
        public int Height()
        {
            //current node's height in the BST is 
            //we want to check both left and right for the longest path
            int leftCheck = 0;
            int rightCheck = 0;

            //recursive case
            //add Left and Right if they arent null. If they are on the same level, only add once and continue down the non null paths
            if (Left != null)
            {
                leftCheck++;
                leftCheck += Left.Height();
            }
            if (Right != null)
            {
                rightCheck++;
                rightCheck += Right.Height();
            }

            //base case = left and right are null
            return (leftCheck >= rightCheck) ? leftCheck : rightCheck;

        }

        /// <summary>
        /// Returns the array representation of the values using breadth-first search.
        /// Time Complexity is O(n) since it needs to go through each character in the string.
        /// Space Complexity is O(1) as the variables are initialized once and updated.
        /// </summary>
        /// <param name="inOrder">The breadth-first search string of the node</param>
        /// <param name="treeCount">The current amount of nodes in the tree</param>
        /// <returns>The array of values in the node added in order of Left-Root-Right</returns>
        public T[] ToArray(string inOrder, int treeCount)
        {
            T[] array = new T[treeCount];

            string[] elements = inOrder.Split(", ");

            for (int i = 0; i < elements.Length; i++)
            {
                array[i] = (T)Convert.ChangeType(elements[i], typeof(T));
            }

            return array;
        }

        /*
        All of the “order” functions above return a string in the format of “v1, v2, …, vn”.
        The structure of this string is very important. Make sure you have a comma and space between each value and no trailing comma or spaces.
         */

        /// <summary>
        /// Returns a string representation of the node in order of Left-Root-Right.
        /// Time Complexity is O(n) because it goes through all values in the node.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the node in a comma separated list in order of Left-Root-Right</returns>
        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Left != null)
            {
                sb.Append(Left.InOrder() + ", ");
            }
            else if (Left != null && Left.Left == null)
            {
                sb.Append(Left.Data.ToString() + ", ");
            }
            sb.Append(Data.ToString());

            if (Right != null)
            {
                sb.Append(", " + Right.InOrder());
            }
            else if (Right != null && Right.Right == null)
            {
                sb.Append(", " + Right.Data.ToString());

            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string representation of the node in order of Root-Left-Right.
        /// Time Complexity is O(n) because it goes through all values in the node.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the node in a comma separated list in order of Root-Left-Right</returns>
        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Data.ToString());

            if (Left != null)
            {
                sb.Append(", " + Left.PreOrder());
            }
            else if (Left != null && Left.Left == null)
            {
                sb.Append(", " + Left.Data.ToString());
            }

            if (Right != null)
            {
                sb.Append(", " + Right.PreOrder());
            }
            else if (Right != null && Right.Right == null)
            {
                sb.Append(", " + Right.Data.ToString());

            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a string representation of the node in order of Left-Right-Root.
        /// Time Complexity is O(n) because it goes through all values in the node.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the node in a comma separated list in order of Left-Right-Root</returns>
        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Left != null)
            {
                sb.Append(Left.PostOrder() + ", ");
            }
            else if (Left != null && Left.Left == null)
            {
                sb.Append(Left.Data.ToString() + ", ");
            }

            if (Right != null)
            {
                sb.Append(Right.PostOrder() + ", ");
            }
            else if (Right != null && Right.Right == null)
            {
                sb.Append(Right.Data.ToString() + ", ");

            }

            sb.Append(Data.ToString());
            return sb.ToString();
        }
    }

    /// <summary>
    /// Node for the AVL Tree. It does not extend the Binary Search Tree Node, despite sharing a few methods, due to tree being unable to differentiate between the two Node types.
    /// It prioritized the Node_BST as the Root if extended, and it was more beneficial to treat the Node_AVL and it's tree as a separate class than derived.
    /// </summary>
    /// <typeparam name="T">Generic type for the node's data type</typeparam>
    public class Node_AVL<T> where T : IComparable<T>
    {
        public T Data { get; set; }

        public Node_AVL<T>? Left { get; set; }
        public Node_AVL<T>? Right { get; set; }
        public Node_AVL(T data) => Data = data;

        /// <summary>
        /// Method that rebalances the tree by checking if the appropriate rotation needs to be executed. Left-Right and Right-Left are executed first if possible as it treats the second rotation as the single rotation.
        /// Left and Right follow, which are executed if possible, regardless of whether it follows the Left-Right or Right-Left rotation.
        /// Time Complexity is O(n) due to the highest complexity being in the Height() method.
        /// Space Complexity is O(1) since all variables are initialized once then updated.
        /// </summary>
        private void Rotation()
        {
            int leftBalance = (Left != null) ? Left.Height() + 1 : 0;
            int rightBalance = (Right != null) ? Right.Height() + 1 : 0;

            int balance = leftBalance - rightBalance;

            //LEFT RIGHT ROTATION
            if (Left != null && Left.Right != null)
            {
                
                if (balance >= 2 && 0 - (Left.Right.Height() + 1) == -1)
                {
                    Node_AVL<T> storeLeft = Left;
                    this.Left = storeLeft.Right;
                    this.Left.Left = storeLeft;
                    this.Left.Left.Right = null;
                }
                
            }

            if (Right != null && Right.Left != null)
            {
                //RIGHT LEFT ROTATION
                if (balance <= -2 && (Right.Left.Height() + 1) - 0 == 1)
                {
                    Node_AVL<T> storeRight = Right;
                    this.Right = storeRight.Left;
                    this.Right.Right = storeRight;
                    this.Right.Right.Left = null;
                }

            }


            //LEFT ROTATION
            if (balance >= 2 && (Left.Left.Height() + 1) - 0 == 1)
            {
                T storedData = this.Data;
                this.Data = Left.Data;
                this.Left = Left.Left;
                this.Right = new Node_AVL<T>(storedData);
            }

            //RIGHT ROTATION
            if (balance <= -2 && 0 - (Right.Right.Height() + 1) == -1)
            {
                T storedData = this.Data;
                this.Data = Right.Data;
                this.Right = Right.Right;
                this.Left = new Node_AVL<T>(storedData);
            }


        }   

        /// <summary>
        /// Adds a value to the Left or Right node of the current node. If the value is equal to the current node Data, it will be added to the Left node.
        /// Time Complexity is O(n) due to the highest complexity being the Rotation() method outside the recursive call.
        /// Space Complexity is O(1) as only one new node is created.
        /// </summary>
        /// <param name="value">The value the new node is being created with</param>
        /// <returns>The node you are adding</returns>
        public Node_AVL<T> Add(T value)
        {
            //check the left and right of the current node (recursive)
            //if value <= node data, check left
            if (value.CompareTo(Data) <= 0)
            {
                //check to see if left is null
                if (Left == null)
                {
                    Left = new Node_AVL<T>(value);
                }
                else
                {
                    Left.Add(value);
                }
                Rotation();
                return Left;
            }
            //if value > node data, check right
            else
            {
                //check to see if right is null
                if (Right == null)
                {
                    Right = new Node_AVL<T>(value);
                }
                else
                {
                    Right.Add(value);
                }
                Rotation();
                return Right;
            }


        }

        /// <summary>
        /// Removes the specified value from the node if it is present, or does nothing if the value is not present.
        /// Time Complexity is O(n) due to the highest complexity being the Rotation() method in the base case.
        /// Space Complexity is O(n) as new variables are initialized every recursive call.
        /// </summary>
        /// <param name="value">The value being remove from the node or its children if it exists</param>
        /// <returns>The node you are removing, or null if not present</returns>
        public Node_AVL<T> Remove(T value)
        {
            //Check to see if the value is contained in the tree before deleting
            if (!Contains(value)) return null;

            //store the current Node's Left and Right
            Node_AVL<T> leftNode = Left;
            Node_AVL<T> rightNode = Right;

            Node_AVL<T> currentNode = this;

            //base case
            if (Data.CompareTo(value) == 0)
            {
                //shift left value if present
                if (leftNode != null)
                {
                    Data = leftNode.Data;
                    if (leftNode.Left != null) Left = leftNode.Left;
                    else Left = null;
                    if (leftNode.Right != null)
                    {
                        Right = leftNode.Right;
                        if (rightNode != null) Right.Right = rightNode;
                    }
                    Rotation();
                }
            }
            else
            //recursive case
            {
                if (value.CompareTo(Data) <= 0)
                {
                    Left.Remove(value);
                    //edge case => Left has no children
                    if (Left.Left == null && Left.Right == null) Left = null;
                }
                else
                {
                    Right.Remove(value);
                    //edge case => Right has no children
                    if (Right.Left == null && Right.Right == null) Right = null;
                    
                }
            }
            return currentNode;
        }

        /// <summary>
        /// Checks the Node and its children for the specified value. It compares the Data to the value and goes to the Left or Right to continue searching.
        /// It goes Left if the value is less than the search value, and goes Right if it's greater than/
        /// Time Complexity is O(log n) since it recursively calls Contains on the Left or Right, cutting searching the whole tree.
        /// Space Complexity is O(1) as it only make comparisons.
        /// </summary>
        /// <param name="value">The value to search for in the Node</param>
        /// <returns>If the node or its children contains the value (true or false)</returns>
        public bool Contains(T value)
        {
            //check ourselves, left, and right
            //the current node has the value
            if (Data.CompareTo(value) == 0) return true;
            else
            {
                if (value.CompareTo(Data) <= 0)
                {
                    if (Left == null) return false;
                    else return Left.Contains(value);
                }
                else
                {
                    if (Right == null) return false;
                    else return Right.Contains(value);
                }
            }
        }

        /// <summary>
        /// Gets the height from the current node, starting at 0.
        /// Time Complexity is O(n) since it needs to check every node to determine height.
        /// Space Complexity is O(n) since the variables will be re-instantiated every recursive call.
        /// </summary>
        /// <returns>The height from the current node</returns>
        public int Height()
        {
            //current node's height in the BST is 
            //we want to check both left and right for the longest path
            int leftCheck = 0;
            int rightCheck = 0;

            //recursive case
            //add Left and Right if they arent null. If they are on the same level, only add once and continue down the non null paths
            if (Left != null)
            {
                leftCheck++;
                leftCheck += Left.Height();
            }
            if (Right != null)
            {
                rightCheck++;
                rightCheck += Right.Height();
            }

            //base case = left and right are null
            return (leftCheck >= rightCheck) ? leftCheck : rightCheck;

        }

        /// <summary>
        /// Returns the array representation of the values using breadth-first search.
        /// Time Complexity is O(n) since it needs to go through each node and its children.
        /// Space Complexity is O(n) as the variables are initialized every recursive call.
        /// </summary>
        /// <returns>The array of values in the node added in order of left to right on each level</returns>
        public T[] ToArray()
        {
            //Variables
            //Using a list to allow for dynamic resizing
            List<T> array = new List<T>();

            int height = 0;

            Node_AVL<T> currentLeft = Left;
            Node_AVL<T> currentRight = Right;

            //Add the current Data to the array
            array.Add(Data);

            //Loop until the calculated height is greater than the actual Height from the Node
            while (height < Height())
            {
                //Go Left to Right on the current level

                //Check to make sure the current left is not null
                if (currentLeft != null)
                {
                    //Recursively call ToArray on the current Left node => this will create an array of the remaining nodes left to right then down
                    //The next element to add is the first element of this subarray
                    array.Add(currentLeft.ToArray().ElementAt(0));
                    //Update the current Left based on surrounding nodes

                    //If the Left of the next level is not null, set the current Left to it
                    if (currentLeft.Left != null) currentLeft = currentLeft.Left;

                    //Else, we are on an inner tree Left. Check to see if the Right and it's Left is not null
                    else if (Right != null && Right.Left != null)
                    {
                        //Add the inner left (Right.Left) to the array
                        array.Add(Right.Left.Data);
                        //set the current Left to null since we are done with the inner left
                        currentLeft = null;
                    }

                }
                //Do the same for the right with the variables flipped

                //check to make sure the current right is not null
                if (currentRight != null)
                {
                    //Recursively call ToArray on the current Right node => this will create an array of the remaining nodes left to right then down
                    //The next element to add is the first element of this subarray
                    array.Add(currentRight.ToArray().ElementAt(0));

                    //Update the current Right based on surrounding nodes

                    //If the Right of the next level is not null, set the current Right to it
                    if (currentRight.Right != null) currentRight = currentRight.Right;

                    //Else, we are on an inner tree Right. Check to see if the Left and it's Right is not null
                    else if (Left != null && Left.Right != null)
                    {
                        //Add the inner right (Left.Right) to the array
                        array.Add(Left.Right.Data);
                        //set the current Right to null since we are done with the inner right
                        currentRight = null;
                    }

                }
                
                //Increment height after going through the level
                height++;
            }

            //return the resulting array
            return array.ToArray();
        }

        /*
        All of the “order” functions above return a string in the format of “v1, v2, …, vn”.
        The structure of this string is very important. Make sure you have a comma and space between each value and no trailing comma or spaces.
         */

        /// <summary>
        /// Returns a string representation of the node in order of Left-Root-Right.
        /// Time Complexity is O(n) because it goes through all values in the node.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the node in a comma separated list in order of Left-Root-Right</returns>
        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Left != null)
            {
                sb.Append(Left.InOrder() + ", ");
            }
            else if (Left != null && Left.Left == null)
            {
                sb.Append(Left.Data.ToString() + ", ");
            }
            sb.Append(Data.ToString());

            if (Right != null)
            {
                sb.Append(", " + Right.InOrder());
            }
            else if (Right != null && Right.Right == null)
            {
                sb.Append(", " + Right.Data.ToString());

            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string representation of the node in order of Root-Left-Right.
        /// Time Complexity is O(n) because it goes through all values in the node.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the node in a comma separated list in order of Root-Left-Right</returns>
        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Data.ToString());

            if (Left != null)
            {
                sb.Append(", " + Left.PreOrder());
            }
            else if (Left != null && Left.Left == null)
            {
                sb.Append(", " + Left.Data.ToString());
            }

            if (Right != null)
            {
                sb.Append(", " + Right.PreOrder());
            }
            else if (Right != null && Right.Right == null)
            {
                sb.Append(", " + Right.Data.ToString());

            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a string representation of the node in order of Left-Right-Root.
        /// Time Complexity is O(n) because it goes through all values in the node.
        /// Space Complexity is O(n) because a new StringBuilder is initialized for every recursive call.
        /// </summary>
        /// <returns>A string of the node in a comma separated list in order of Left-Right-Root</returns>
        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Left != null)
            {
                sb.Append(Left.PostOrder() + ", ");
            }
            else if (Left != null && Left.Left == null)
            {
                sb.Append(Left.Data.ToString() + ", ");
            }

            if (Right != null)
            {
                sb.Append(Right.PostOrder() + ", ");
            }
            else if (Right != null && Right.Right == null)
            {
                sb.Append(Right.Data.ToString() + ", ");

            }

            sb.Append(Data.ToString());
            return sb.ToString();
        }
    }
}
