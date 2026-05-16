using NS_Tree;
using System.Text;
using Xunit;

namespace NodeStrategy
{
    public class Node<T> : NodeStrategy<T>
    {
        public string StrategyFamily { get; set; } = "DEFAULT";
        public T? Data { get; set; }
        virtual public Dictionary<string, Node<T>> Nodes => new Dictionary<string, Node<T>>();

        // Default
        public Node() { }
        //With Data
        public Node(T data)
        {
            this.Data = data;
        }
        virtual public void Add(T value) { }
        virtual public bool Contains(T value) { return false; }
        virtual public void Remove(T value) { }
        virtual public int Height(string[] names = null)
        {
            //current node's height in the BST is 
            //we want to check both left and right for the longest path
            int leftCheck = 0;
            int rightCheck = 0;

            //recursive case
            //add Left and Right if they arent null. If they are on the same level, only add once and continue down the non null paths
            if (Nodes[names[0]] != null)
            {
                leftCheck++;
                leftCheck += Nodes[names[0]].Height(names);
            }
            if (Nodes[names[1]] != null)
            {
                rightCheck++;
                rightCheck += Nodes[names[1]].Height(names);
            }

            //base case = left and right are null
            return (leftCheck >= rightCheck) ? leftCheck : rightCheck;
        }
        virtual public string InOrder(string[] names)
        {

            StringBuilder sb = new StringBuilder();
            if (Nodes[names[0]] != null)
            {
                sb.Append(Nodes[names[0]].InOrder(names) + ", ");
            }
            else if (Nodes[names[0]] != null && Nodes[names[0]].Nodes[names[0]] == null)
            {
                sb.Append(Nodes[names[0]].Data.ToString() + ", ");
            }
            sb.Append(Data.ToString());

            if (Nodes[names[1]] != null)
            {
                sb.Append(", " + Nodes[names[1]].InOrder(names));
            }
            else if (Nodes[names[1]] != null && Nodes[names[1]].Nodes[names[1]] == null)
            {
                sb.Append(", " + Nodes[names[1]].Data.ToString());

            }
            return sb.ToString();
        }
        virtual public string PreOrder(string[] names)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Data.ToString());

            if (Nodes[names[0]] != null)
            {
                sb.Append(", " + Nodes[names[0]].PreOrder(names));
            }
            else if (Nodes[names[0]] != null && Nodes[names[0]].Nodes[names[0]] == null)
            {
                sb.Append(", " + Nodes[names[0]].Data.ToString());
            }

            if (Nodes[names[1]] != null)
            {
                sb.Append(", " + Nodes[names[1]].PreOrder(names));
            }
            else if (Nodes[names[1]] != null && Nodes[names[1]].Nodes[names[1]] == null)
            {
                sb.Append(", " + Nodes[names[1]].Data.ToString());

            }

            return sb.ToString();
        }
        virtual public string PostOrder(string[] names)
        {
            StringBuilder sb = new StringBuilder();
            if (Nodes[names[0]] != null)
            {
                sb.Append(Nodes[names[0]].PostOrder(names) + ", ");
            }
            else if (Nodes[names[0]] != null && Nodes[names[0]].Nodes[names[0]] == null)
            {
                sb.Append(Nodes[names[0]].Data.ToString() + ", ");
            }

            if (Nodes[names[1]] != null)
            {
                sb.Append(Nodes[names[1]].PostOrder(names) + ", ");
            }
            else if (Nodes[names[1]] != null && Nodes[names[1]].Nodes[names[1]] == null)
            {
                sb.Append(Nodes[names[1]].Data.ToString() + ", ");

            }

            sb.Append(Data.ToString());
            return sb.ToString();
        }
    }
    public interface NodeStrategy<T>
    {
        string StrategyFamily { get; set; }
        Dictionary<string, Node<T>> Nodes { get; }
        public void Add(T value) { }
        public bool Contains(T value) { return false; }
        public void Remove(T value) { }
        public int Height(string[] names = null) { return -1; }
        public string InOrder(string[] names) { return ""; }
        public string PreOrder(string[] names) { return ""; }
        public string PostOrder(string[] names) { return ""; }
    }
    public class NodeContext<T>
    {
        private NodeStrategy<T> nodeStrategy;
        public NodeContext(NodeStrategy<T> nodeStrategy)
        {
            this.nodeStrategy = nodeStrategy;
        }
        public void setNodeStrategy(NodeStrategy<T> nodeStrategy)
        {
            this.nodeStrategy = nodeStrategy;
        }

        public void performAdd(T value)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) nodeStrategy.Add(value);
        }

        public bool performContains(T value)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) return nodeStrategy.Contains(value);
            else return false;
        }
        public void performRemove(T value)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) nodeStrategy.Remove(value);
        }
        public int performHeight(string[] names = null)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) return nodeStrategy.Height(names);
            else return -1;
        }

        public string performInOrder(string[] names = null)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) return nodeStrategy.InOrder(names);
            return "";
        }
        public string performPreOrder(string[] names = null)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) return nodeStrategy.PreOrder(names);
            return "";
        }
        public string performPostOrder(string[] names = null)
        {
            if (nodeStrategy.StrategyFamily.Equals("TREE")) return nodeStrategy.PostOrder(names);
                return "";
            }
        }

        //Example of how this would be used

        public class Main
        {
            public void RunMain()
            {
                NodeStrategy<int> BinarySearchTreeStrategy = new NodeStrategy_BST<int>();
                NodeStrategy<int> AdelsonVelskyLandisStrategy = new NodeStrategy_AVL<int>();

                NodeContext<int> nodeContext = new NodeContext<int>(BinarySearchTreeStrategy);

                nodeContext.performAdd(1);
                nodeContext.performAdd(2);
                nodeContext.performAdd(5);
                nodeContext.performAdd(4);

                Assert.False(nodeContext.performContains(7));
                Assert.True(nodeContext.performContains(4));

                Console.WriteLine(nodeContext.performHeight());

                nodeContext.performRemove(4);
                Assert.False(nodeContext.performContains(4));

                nodeContext.setNodeStrategy(AdelsonVelskyLandisStrategy);

                nodeContext.performAdd(4);
                nodeContext.performAdd(1);
                nodeContext.performAdd(2);
                nodeContext.performAdd(6);

                Console.WriteLine(nodeContext.performInOrder());
                Console.WriteLine(nodeContext.performPreOrder());
                Console.WriteLine(nodeContext.performPostOrder());
            }
        }
    }
}

