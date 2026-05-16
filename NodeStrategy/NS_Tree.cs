using NodeStrategy;

namespace NS_Tree
{
    public class NodeStrategy_BST<T> : Node<T> where T : IComparable<T>
    {
        
        override public Dictionary<string, Node<T>> Nodes =>
            new Dictionary<string, Node<T>>
            {
                { "Left", new NodeStrategy_BST<T>() },
                { "Right", new NodeStrategy_BST<T>() }
            };
        public NodeStrategy_BST() : base() { StrategyFamily = "TREE"; }
        public NodeStrategy_BST(T data) : base(data) { StrategyFamily = "TREE"; }

        override public void Add(T value)
        {
            //check the left and right of the current node (recursive)
            //if value <= node data, check left
            if (value.CompareTo(Data) <= 0)
            {
                //check to see if left is null
                if (Nodes["Left"] == null)
                {
                    Nodes["Left"] = new NodeStrategy_BST<T>(value);
                }
                else
                {
                    (Nodes["Left"] as NodeStrategy_BST<T>).Add(value);
                }
            }
            //if value > node data, check right
            else
            {
                if (Nodes["Right"] == null)
                {
                    Nodes["Right"] = new NodeStrategy_BST<T>(value);
                }
                else
                {
                    (Nodes["Right"] as NodeStrategy_BST<T>).Add(value);
                }
            }

        }

        override public bool Contains(T value)
        {
            //check ourselves, left, and right

            //the current node has the value
            if (Data.CompareTo(value) == 0) return true;
            else
            {
                if (value.CompareTo(Data) <= 0)
                {
                    if (Nodes["Left"] == null) return false;
                    else return (Nodes["Left"] as NodeStrategy_BST<T>).Contains(value);
                }
                else
                {
                    if (Nodes["Right"] == null) return false;
                    else return (Nodes["Right"] as NodeStrategy_BST<T>).Contains(value);
                }
            }
        }

        override public void Remove(T value)
        {
            //Check to see if the value is contained in the tree before deleting
            if (!Contains(value)) return;

            //store the current Node's Left and Right
            NodeStrategy_BST<T> leftNode = Nodes["Left"] as NodeStrategy_BST<T>;
            NodeStrategy_BST<T> rightNode = Nodes["Right"] as NodeStrategy_BST<T>;

            //base case
            if (Data.CompareTo(value) == 0)
            {
                //shift left value if present
                if (leftNode != null)
                {
                    Data = leftNode.Data;
                    if (leftNode.Nodes["Left"] != null) Nodes["Left"] = leftNode.Nodes["Left"];
                    else Nodes["Left"] = null;
                    if (leftNode.Nodes["Right"] != null)
                    {
                        Nodes["Right"] = leftNode.Nodes["Right"];
                        if (rightNode != null) (Nodes["Right"] as NodeStrategy_BST<T>).Nodes["Right"] = rightNode;
                    }
                }
            }
            else
            //recursive case
            {
                if (value.CompareTo(Data) <= 0)
                {
                    (Nodes["Left"] as NodeStrategy_BST<T>).Remove(value);
                    //edge case => Left has no children
                    if ((Nodes["Left"] as NodeStrategy_BST<T>).Nodes["Left"] == null && (Nodes["Left"] as NodeStrategy_BST<T>).Nodes["Right"] == null) Nodes["Left"] = null;
                }
                else
                {
                    (Nodes["Right"] as NodeStrategy_BST<T>).Remove(value);
                    //edge case => right has no children
                    if ((Nodes["Right"] as NodeStrategy_BST<T>).Nodes["Left"] == null && (Nodes["Right"] as NodeStrategy_BST<T>).Nodes["Right"] == null) Nodes["Right"] = null;
                }
            }

        }

        override public int Height(string[] names = null)
        {
            return base.Height(new string[] { "Left", "Right" });

        }

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

        override public string InOrder(string[] names = null)
        {
            return base.InOrder(new string[] { "Left", "Right" });
        }

        override public string PreOrder(string[] names = null)
        {
            return base.PreOrder(new string[] { "Left", "Right" });
        }

        override public string PostOrder(string[] names = null)
        {
            return base.PostOrder(new string[] { "Left", "Right" });
        }

    }

    public class NodeStrategy_AVL<T> : Node<T> where T : IComparable<T>
    {
        public NodeStrategy_AVL() : base() { StrategyFamily = "TREE"; }
        public NodeStrategy_AVL(T data) : base(data) { StrategyFamily = "TREE"; }
        override public Dictionary<string, Node<T>> Nodes =>
            new Dictionary<string, Node<T>>
            {
                { "Left", new NodeStrategy_AVL<T>() },
                { "Right", new NodeStrategy_AVL<T>() }
            };

        private void Rotation()
        {
            int leftBalance = (Nodes["Left"] != null) ? Nodes["Left"].Height() + 1 : 0;
            int rightBalance = (Nodes["Right"] != null) ? Nodes["Right"].Height() + 1 : 0;

            int balance = leftBalance - rightBalance;

            //LEFT RIGHT ROTATION
            if (Nodes["Left"] != null && Nodes["Left"].Nodes["Right"] != null)
            {

                if (balance >= 2 && 0 - (Nodes["Left"].Nodes["Right"].Height() + 1) == -1)
                {
                    NodeStrategy_AVL<T> storeLeft = Nodes["Left"] as NodeStrategy_AVL<T>;
                    this.Nodes["Left"] = storeLeft.Nodes["Right"];
                    this.Nodes["Left"].Nodes["Left"] = storeLeft;
                    this.Nodes["Left"].Nodes["Left"].Nodes["Right"] = null;
                }

            }

            if (Nodes["Right"] != null && Nodes["Right"].Nodes["Left"] != null)
            {
                //RIGHT LEFT ROTATION
                if (balance <= -2 && (Nodes["Right"].Nodes["Left"].Height() + 1) - 0 == 1)
                {
                    NodeStrategy_AVL<T> storeRight = Nodes["Right"] as NodeStrategy_AVL<T>;
                    this.Nodes["Right"] = storeRight.Nodes["Right"];
                    this.Nodes["Right"].Nodes["Right"] = storeRight;
                    this.Nodes["Right"].Nodes["Right"].Nodes["Left"] = null;
                }

            }


            //LEFT ROTATION
            if (balance >= 2 && (Nodes["Left"].Nodes["Left"].Height() + 1) - 0 == 1)
            {
                T storedData = this.Data;
                this.Data = Nodes["Left"].Data;
                this.Nodes["Left"] = Nodes["Left"].Nodes["Left"];
                this.Nodes["Right"] = new NodeStrategy_AVL<T>(storedData);
            }

            //RIGHT ROTATION
            if (balance <= -2 && 0 - (Nodes["Right"].Nodes["Right"].Height() + 1) == -1)
            {
                T storedData = this.Data;
                this.Data = Nodes["Right"].Data;
                this.Nodes["Right"] = Nodes["Right"].Nodes["Right"];
                this.Nodes["Left"] = new NodeStrategy_AVL<T>(storedData);
            }


        }

        override public void Add(T value)
        {
            //check the left and right of the current node (recursive)
            //if value <= node data, check left
            if (value.CompareTo(Data) <= 0)
            {
                //check to see if left is null
                if (Nodes["Left"] == null)
                {
                    Nodes["Left"] = new NodeStrategy_AVL<T>(value);
                }
                else
                {
                    (Nodes["Left"] as NodeStrategy_AVL<T>).Add(value);
                }
                Rotation();
                return;
            }
            //if value > node data, check right
            else
            {
                //check to see if right is null
                if (Nodes["Right"] == null)
                {
                    Nodes["Right"] = new NodeStrategy_AVL<T>(value);
                }
                else
                {
                    (Nodes["Right"] as NodeStrategy_AVL<T>).Add(value);
                }
                Rotation();
                return;
            }


        }

        override public void Remove(T value)
        {
            //Check to see if the value is contained in the tree before deleting
            if (!Contains(value)) return;

            //store the current Node's Left and Right
            NodeStrategy_AVL<T> leftNode = Nodes["Left"] as NodeStrategy_AVL<T>;
            NodeStrategy_AVL<T> rightNode = Nodes["Right"] as NodeStrategy_AVL<T>;

            //base case
            if (Data.CompareTo(value) == 0)
            {
                //shift left value if present
                if (leftNode != null)
                {
                    Data = leftNode.Data;
                    if (leftNode.Nodes["Left"] != null) Nodes["Left"] = leftNode.Nodes["Left"];
                    else Nodes["Left"] = null;

                    if (leftNode.Nodes["Right"] != null)
                    {
                        Nodes["Right"] = leftNode.Nodes["Right"];
                        if (rightNode != null) Nodes["Right"].Nodes["Right"] = rightNode;
                    }
                    Rotation();
                }
            }
            else
            //recursive case
            {
                if (value.CompareTo(Data) <= 0)
                {
                    Nodes["Right"].Remove(value);
                    //edge case => Left has no children
                    if (Nodes["Left"].Nodes["Left"] == null && Nodes["Left"].Nodes["Right"] == null) Nodes["Left"] = null;
                }
                else
                {
                    Nodes["Left"].Remove(value);
                    //edge case => Right has no children
                    if (Nodes["Right"].Nodes["Left"] == null && Nodes["Right"].Nodes["Right"] == null) Nodes["Right"] = null;

                }
            }
        }

        override public bool Contains(T value)
        {
            //check ourselves, left, and right
            //the current node has the value
            if (Data.CompareTo(value) == 0) return true;
            else
            {
                if (value.CompareTo(Data) <= 0)
                {
                    if (Nodes["Left"] == null) return false;
                    else return Nodes["Left"].Contains(value);
                }
                else
                {
                    if (Nodes["Right"] == null) return false;
                    else return Nodes["Right"].Contains(value);
                }
            }
        }

        override public int Height(string[] names = null)
        {
            return base.Height(new string[] { "Left", "Right" });

        }

        public T[] ToArray()
        {
            //Variables
            //Using a list to allow for dynamic resizing
            List<T> array = new List<T>();

            int height = 0;

            NodeStrategy_AVL<T> currentLeft = Nodes["Left"] as NodeStrategy_AVL<T>;
            NodeStrategy_AVL<T> currentRight = Nodes["Right"] as NodeStrategy_AVL<T>;

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
                    if (currentLeft.Nodes["Left"] != null) currentLeft = currentLeft.Nodes["Left"] as NodeStrategy_AVL<T>;

                    //Else, we are on an inner tree Left. Check to see if the Right and it's Left is not null
                    else if (Nodes["Right"] != null && Nodes["Right"].Nodes["Left"] != null)
                    {
                        //Add the inner left (Right.Left) to the array
                        array.Add(Nodes["Right"].Nodes["Left"].Data);
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
                    if (currentRight.Nodes["Right"] != null) currentRight = currentRight.Nodes["Right"] as NodeStrategy_AVL<T>;

                    //Else, we are on an inner tree Right. Check to see if the Left and it's Right is not null
                    else if (Nodes["Left"] != null && Nodes["Left"].Nodes["Right"] != null)
                    {
                        //Add the inner right (Left.Right) to the array
                        array.Add(Nodes["Left"].Nodes["Right"].Data);
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

        override public string InOrder(string[] names = null)
        {
            return base.InOrder(new string[] { "Left, Right" });
        }

        override public string PreOrder(string[] names = null)
        {
            return base.PreOrder(new string[] { "Left", "Right" });
        }

        override public string PostOrder(string[] names = null)
        {
            return base.PostOrder(new string[] { "Left", "Right" });
        }
    }
}
