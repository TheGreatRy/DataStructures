using System;
using System.Reflection;
using System.Text;

namespace LinkedListLibrary
{
    public class SingleLinkedList<T>
    {
        public Node_S<T>? Head { get; set; } = new Node_S<T> { Index = -1 };

        /// <summary>
        /// Returns the number of values in the list. A managed value that is stored and updated as needed and not simply derived each time Count is called.
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Puts a new value at the end of the list.
        /// Time Complexity is O(n) as it loops until a null node is found.
        /// Space Complexity is O(1) as it only creates one new node.
        /// </summary>
        /// <param name="value">the value to add to the list in a new Node</param>
        public void Add(T? value)
        {
            if (value == null) return;
            //If the Head does not have data, add to the Head. Return since it is the only node
            if (Head.Index.Equals(-1))
            {
                Head.Index = 0;
                Head.Data = value;
                Count++;
                return;
            }

            //else, we need a new node to be added
            Node_S<T> addNode = new Node_S<T>(value, Count);

            //Start at the Head of the List
            Node_S<T> currentNode = Head;
            //Go down the chain of next until one doesn't have a valid Next
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            //When it breaks out the loop, add the Node to the current Next
            currentNode.Next = addNode;
            //Increment Count
            Count++;
        }

        /// <summary>
        /// Inserts a new value at a given index, pushing the existing value at that index to the next index spot, and so on. 
        /// Time Complexity is O(n^2) as it loops to shift the indices of the nodes after the insert adds complexity with the Get method.
        /// Space Complexity is O(1) as it new variables only get instantiated once.
        /// </summary>
        /// <param name="value">The value to add to the list in a new Node</param>
        /// <param name="index">The index to insert the new Node into</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index less is than zero or equal to or greater than Count</exception>   
        public void Insert(T value, int index)
        {
            if (value == null) return;

            //Index out of bound check
            if (index < 0 || index > 0 && index >= Count) throw new IndexOutOfRangeException();

            if (Head.Index == -1 && index == 0)
            {
                Head = new Node_S<T>(value, index);
                Count++;
                return;
            }

            //initialize the Node => it will have the index of the last element
            Node_S<T> insertNode = new Node_S<T>(value, Count);

            //shift the indices from the index
            for (int i = Count -1; i >= index; i--)//O(n)
            {
                Get(i).Index += 1;//O(n)
            }
            Count++;
            insertNode.Index = index;

            if (!(index - 1 < 0))
            {
                Node_S<T> temp = Get(index);
                Get(index - 1).Next = insertNode;
                Get(index).Next = temp;
            }
            else if (index - 1 < 0)
            {
                Node_S<T> temp = Get(index);
                Head = insertNode;
                Head.Next = temp;
            }
        }

        /// <summary>
        /// Returns the value at the given index.
        /// Time Complexity is O(n) as it loops until the node at the index is found.
        /// Space Complexity is O(1) as it only creates one variable.
        /// </summary>
        /// <param name="index">The index of the Node you are trying to get</param>
        /// <returns>The Node you are trying get</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is less than zero or equal to or greater than Count</exception>
        public Node_S<T> Get(int index)
        {
            //Index out of bound check
            if (index < 0 || index > 0 && index >= Count) throw new IndexOutOfRangeException();
            
            //Start at the Head of the List
            Node_S<T> currentNode = Head;
            while (currentNode.Index < index)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// Removes and returns the first value in the list.
        /// Time Complexity is O(n^2) as it loops until it shifts the indices of the list and adds complexity with the Get method.
        /// Space Complexity is O(1) as it only creates one variable.
        /// </summary>
        /// <returns>The Node you are removing</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public Node_S<T> Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node_S<T> removeNode = Head;
            if (Count == 1)
            {
                Head = null;
            }
            else 
            {
                Node_S<T> temp = Get(1);
                Head = temp;
                //shift the indices from the index
                for (int i = Count - 1; i > 0; i--) //O(n)
                {
                    Get(i).Index -= 1; //O(n)
                }
            }

            Count--;
            return removeNode;
        }

        /// <summary>
        /// Removes and returns the value at a given index.
        /// Time Complexity is O(n) as it loops until it shifts the indices of the list and the methods it calls do not add further complexities.
        /// Space Complexity is O(1) as it only creates one instance of variables.
        /// </summary>
        /// <param name="index">The index of the Node to remove</param>
        /// <returns>The Node you are removing</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is less than zero or equal to or greater than Count</exception>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public Node_S<T> RemoveAt(int index)
        {
            //Index out of bound check
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node_S<T> removeNode = Get(index);
            if (Count == 1)
            {
                Head = null;
            }
            else
            {
                if (index == 0)
                {
                    this.Remove();
                    return removeNode;
                }
                else if (index == Count - 1)
                {
                    this.RemoveLast();
                    return removeNode;
                }
                Node_S<T> temp = Get(index + 1);
                Get(index - 1).Next = temp;
                //shift the indices from the index
                for (int i = Count - 1; i > index; i--)
                {
                    Get(i).Index -= 1;
                }
            }

            Count--;


            return removeNode;
        }

        /// <summary>
        /// Removes and returns the last value in the list.
        /// Time Complexity is O(n) as the Get method is it's highest complexity.
        /// Space Complexity is O(1), no temporary variables.
        /// </summary>
        /// <returns>The Node you are removing</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public Node_S<T> RemoveLast()
        {
            Node_S<T> removeNode = Get(Count - 1);
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            else if (Count == 1)
            {
                Head = null;
            }
            else
            {
                Get(Count - 2).Next = null;
            }
            Count--;
            return removeNode;
        }

        /// <summary>
        /// An override method that creates and returns a string representation of all the values in the list. 
        /// An empty list will return an empty string (but not null).
        /// Time Complexity is O(n^2) since it loops through the entire list and the Get method adds complexity.
        /// Space Complexity is O(1) since it's only instantiates variables once .
        /// </summary>
        /// <returns>The list of values separated by commas, or empty</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            Node_S<T>? node;
            for (int i = 0; i < Count; i++)//O(n)
            {
                node = Get(i); //O(n)
                sb.Append(node.Data.ToString());
                if(i < Count - 1) sb.Append(", ");
            }
            return sb.ToString();
        }

        //// <summary>
        /// Removes all values in the list
        /// Time and Space Complexity is O(1) as it will always only reset the head node and count
        /// </summary>
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Searches for a value in the list and returns the first index of that value when found. If the key is not found in the list, the method returns -1.
        /// Time Complexity is O(n) since it has to loop through n Nexts to find a null.
        /// Space Complexity is O(1) as it's not creating any new nodes to search for the values.
        /// </summary>
        /// <param name="value">The value you are searching for in the list</param>
        /// <returns>The index of the Node that contains the value, or -1</returns>
        public int Search(T value)
        {
            if (value == null) return -1;
            //Start at the Head of the List
            Node_S<T> currentNode = Head;
            while (!currentNode.Data.Equals(value))
            {
                currentNode = currentNode.Next;
                if (currentNode.Next == null) break;
            }

            if (currentNode.Data.Equals(value))
            {
                return currentNode.Index;
            }

            return -1;

            
        }
    }
}