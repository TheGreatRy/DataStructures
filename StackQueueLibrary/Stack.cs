using LinkedListLibrary;

namespace StackQueueLibrary
{
    public class Stack<T> : SingleLinkedList<T>
    {
        /// <summary>
        /// Returns  true if the value exists in the stack, otherwise, false.
        /// Time Complexity is O(n) since it's highest complexity is the Search method.
        /// Space Complexity is O(1) as it's only evaluating conditions and instantiates variable once.
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>If the stack contains the value (true or false) </returns>
        public bool Contains(T value)
        {
            //search for the value, evaluate for a valid index
            int eval = Search(value); //O(n)
            //if Search returns -1 (not found), return false
            if (eval == -1) return false;
            //else, it found a valid index => return true
            else return true;
        }

        /// <summary>
        /// Return the item on the top without removing it.
        /// Time Complexity is O(n) since it's highest complexity is the Get method.
        /// Space Complexity is O(1) since Get doesn't add further space complexity.
        /// </summary>
        /// <returns>The node at the top of the stack</returns>
        public Node_S<T> Peek()
        {
            return Get(0);
        }
 
        /// <summary>
        /// Remove and return the top item.
        /// Time Complexity is O(n^2) since it's highest complexity is the Remove method.
        /// Space Complexity is O(1) since Remove doesn't add further space complexity.
        /// </summary>
        /// <returns>The node at the top of the stack</returns>
        public Node_S<T> Pop()
        {
            return Remove();
        }

        /// <summary>
        /// Add an item to the stack. Uses insert so it can be added to the top of the stack.
        /// Time Complexity is O(n^2) since it's highest complexity is the Insert method.
        /// Space Complexity is O(1) since Insert doesn't add further space complexity.
        /// </summary>
        /// <param name="value">The value to add to the stack</param>
        public void Push(T value)
        {
            Insert(value, 0);
        }
    }
}
