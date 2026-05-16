using NodeStrategy;

namespace NS_LinkedList
{
    public class NodeStrategy_S<T> : Node<T>
    {
        override public Dictionary<string, Node<T>> Nodes =>
            new Dictionary<string, Node<T>>
            {
                { "Next", new NodeStrategy_S<T>() }
            };
        public int Index { get; set; }
        public NodeStrategy_S(T data, int index)
        {
            Data = data;
            Index = index;
        }
        public NodeStrategy_S() { }

    }
    public class NodeStrategy_D<T> : Node<T>
    {
        override public Dictionary<string, Node<T>> Nodes =>
            new Dictionary<string, Node<T>>
            {
                { "Previous", new NodeStrategy_D<T>() },
                { "Next", new NodeStrategy_D<T>() }
            };
        public int Index { get; set; }
        public NodeStrategy_D(T data, int index)
        {
            Data = data;
            Index = index;
        }
        public NodeStrategy_D() { }
    }
}
