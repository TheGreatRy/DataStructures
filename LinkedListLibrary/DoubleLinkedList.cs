using System;
using System.Reflection;
using System.Text;

namespace LinkedListLibrary
{
    public class DoubleLinkedList<T>
    {
        public Node_D<T>? Head { get; set; } = new Node_D<T> { Index = -1 };
        public Node_D<T>? Tail { get; set; } = new Node_D<T> { Index = -2 };

        /// <summary>
        /// Returns the number of values in the list. A managed value that is stored and updated as needed and not simply derived each time Count is called.
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Puts a new value at the Tail of the list
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
            //else if the Head is valid but not the Tail, add the second value to the Tail
            else if (Tail.Index.Equals(-2))
            {
                Tail.Index = 1;
                Tail.Data = value;

                Tail.Previous = Head;
                Head.Next = Tail;

                Count++;
                return;
            }

            //else, add the value to the Tail and shift it
            Node_D<T> addNode = new Node_D<T>(value, Count);
            
            //Start at the Head of the List
            Node_D<T> currentNode = Head;
            //Go down the chain of next until one doesn't have a valid Next
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            //update current node to have the new Tail
            currentNode.Next = addNode;
            currentNode.Previous = Tail;

            //Update Tail node
            Tail = currentNode.Next;
            currentNode = Tail;

            //Update the previous nodes in relation to the new Tail
            while (currentNode.Index > 0)
            {
                currentNode.Previous = Get(currentNode.Index - 1);
                currentNode = currentNode.Previous;
            }

            //Increment Count
            Count++;
        }

        /// <summary>
        /// Inserts a new value at a given index, pushing the existing value at that index to the next index spot, and so on.
        /// </summary>
        /// <param name="value">The value to add to the list in a new Node</param>
        /// <param name="index">The index to insert the new Node into</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index less is than zero or equal to or greater than Count</exception>     
        public void Insert(T? value, int index)
        {
            if (value == null) return;

            //Index out of bound check
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            //initialize the Node => it will have the index of the last element
            Node_D<T> insertNode = new Node_D<T>(value, Count);

            //shift the indices from the index
            for (int i = Count - 1; i >= index; i--)
            {
                Get(i).Index += 1;
            }
            Count++;
            insertNode.Index = index;

            
            //head
            if (index - 1 < 0)
            {
                Node_D<T> temp = Get(index);
                Head = insertNode;
                Head.Next = temp;
            }
            //tail
            else if(index - 1 == Count - 1)
            {
                Node_D<T> temp = Get(index);
                Tail = insertNode;
                Tail.Previous = temp;
            }
            //middle
            else if (index - 1 < Count - 1)
            {
                Node_D<T> temp = Get(index);
                Get(index - 1).Next = insertNode;
                Get(index).Next = temp;
            }
        }

        /// <summary>
        /// Returns the value at the given index
        /// </summary>
        /// <param name="index">The index of the Node you are trying to get</param>
        /// <returns>The Node you are trying get</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is less than zero or equal to or greater than Count</exception>
        public Node_D<T> Get(int index)
        {
            //Index out of bound check
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            
            //Start at the Head of the List
            Node_D<T> currentNode = Head;
            while (currentNode.Index < index)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// Removes and returns the first value in the list
        /// </summary>
        /// <returns>The Node you are removing</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public Node_D<T> Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node_D<T> removeNode = Head;
            if (Count == 1)
            {
                Head = null;
            }
            else if (Count == 2)
            {
                Head = Tail;
                Head.Previous = null;
                Tail = null;
            }
            else
            {
                Node_D<T> temp = Get(1);
                Head = temp;
                //shift the indices from the index
                for (int i = Count - 1; i > 0; i--)
                {
                    Get(i).Index -= 1;
                }
            }

            Count--;
            return removeNode;
        }

        /// <summary>
        /// Removes and returns the value at a given index
        /// </summary>
        /// <param name="index">The index of the Node to remove</param>
        /// <returns>The Node you are removing</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is less than zero or equal to or greater than Count</exception>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public Node_D<T> RemoveAt(int index)
        {
            //Index out of bound check
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node_D<T> removeNode = Get(index);
            if (Count == 1)
            {
                Head = null;
            }
            else if (Count == 2)
            {
                if (index == 0)
                {
                    Head = Tail;
                    Head.Previous = null;
                    Tail = null;
                }
                else
                {
                    Head.Next = null;
                    Tail = null;
                }
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

                Get(index + 1).Previous = Get(index - 1);
                Node_D<T> temp = Get(index + 1);

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
        /// Removes and returns the last value in the list
        /// </summary>
        /// <returns>The Node you are removing</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public Node_D<T> RemoveLast()
        {
            Node_D<T> removeNode = Tail;
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            else if (Count == 1)
            {
                Head = null;
            }
            else if (Count == 2)
            {
                Tail = null;
            }
            else
            {
                Tail = Get(Count - 2);
                Tail.Next = null;
            }
            Count--;
            return removeNode;
        }

        /// <summary>
        /// An override method that creates and returns a string representation of all the values in the list. An empty list will return an empty string (but not null)
        /// </summary>
        /// <returns>The list of values separated by commas, or empty</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            for (int i = 0; i < Count; i++)
            {
                Node_D<T>? node = Get(i);
                sb.Append(node.Data.ToString());
                if(i < Count - 1) sb.Append(", ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Removes all values in the list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Searches for a value in the list and returns the first index of that value when found. If the key is not found in the list, the method returns -1
        /// </summary>
        /// <param name="value">The value you are searching for in the list</param>
        /// <returns>The index of the Node that contains the value, or -1</returns>
        public int Search(T? value)
        {
            if (value == null) return -1;

            Node_D<T> currentNode = Head;

            while (!currentNode.Data.Equals(value))
            {
                currentNode = currentNode.Next;
                if (currentNode.Next == null) return -1;
            }

            if (currentNode != null)
            {
                return currentNode.Index;
            }

            return -1;



        }
    }
}