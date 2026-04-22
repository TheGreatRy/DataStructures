using System;

namespace LinkedListLibrary
{
    public class Node_S<T>
    {
        public T? Data { get; set; }
        public Node_S<T>? Next { get; set; }
        public Node_S(T data, int index)
        {
            Data = data;
            Index = index;
        }
        public Node_S() { }

        public int Index { get; set; }
    }
    public class Node_D<T> : Node_S<T>
    {
        public Node_D<T>? Previous { get; set; }
        public new Node_D<T>? Next { get; set; }
        public Node_D(T data, int index)
        {
            Data = data;
            Index = index;
        }
        public Node_D() { }
    }
}
