using Xunit;
namespace TesterDecorator
{
    public class Test<T1, T2>
    {
        virtual public void runTest(T2 expected, T2 actual) 
        { 
            Assert.Equal(expected, actual);
        }
        virtual public void populate(T1[] values) {}
    }
    public class TestDecorator <T1, T2> : Test<T1, T2>
    {
        protected Test<T1, T2> decoratedTest;
        public TestDecorator(Test<T1, T2> test)
        {
            decoratedTest = test;
        }
        public override void runTest(T2 expected, T2 actual)
        {
            decoratedTest.runTest(expected, actual);
        }
        public override void populate(T1[] values) 
        {
            decoratedTest.populate(values);
        }
    }
    public class SLLTestDecorator<T1, T2> : TestDecorator<T1, T2>
    {
        public SingleLinkedList<T1> singleLinkedList;
        public SLLTestDecorator(Test<T1, T2> test) : base(test) { }
        
        public override void runTest(T2 expected, T2 actual)
        {
            decoratedTest.runTest(expected, actual);
        }
        public override void populate(T1[] values)
        {
            singleLinkedList = new SingleLinkedList<T1>();
            for (int i = 0; i < values.Length; i++)
            {
                singleLinkedList.Add(values[i]);
            }
        }
    }
    public class DLLTestDecorator<T1, T2> : TestDecorator<T1, T2>
    {
        public DoubleLinkedList<T1> doubleLinkedList;
        public DLLTestDecorator(Test<T1, T2> test) : base(test) { }

        public override void runTest(T2 expected, T2 actual)
        {
            decoratedTest.runTest(expected, actual);
        }
        public override void populate(T1[] values)
        {
            doubleLinkedList = new DoubleLinkedList<T1>();
            for (int i = 0; i < values.Length; i++)
            {
                doubleLinkedList.Add(values[i]);
            }
        }
    }
    public class StackTestDecorator<T1, T2> : TestDecorator<T1, T2>
    {
        public Stack<T1> stack;
        public StackTestDecorator(Test<T1, T2> test) : base(test) { }

        public override void runTest(T2 expected, T2 actual)
        {
            decoratedTest.runTest(expected, actual);
        }
        public override void populate(T1[] values)
        {
            stack = new Stack<T1>();
            for (int i = 0; i < values.Length; i++)
            {
                stack.Push(values[i]);
            }
        }
    }
    public class QueueTestDecorator<T1, T2> : TestDecorator<T1, T2>
    {
        public Queue<T1> queue;
        public QueueTestDecorator(Test<T1, T2> test) : base(test) { }

        public override void runTest(T2 expected, T2 actual)
        {
            decoratedTest.runTest(expected, actual);
        }
        public override void populate(T1[] values)
        {
            queue = new Queue<T1>(); 
            for (int i = 0; i < values.Length; i++)
            {
                queue.Enqueue(values[i]);
            }
        }
    }
    public class MSTTestDecorator<T1, T2> : TestDecorator<string, T2>
    {
        public Graph graph;
        public List<Edge> edges;
        public MSTTestDecorator(Test<string, T2> test) : base(test) { }
        public override void runTest(T2 expected, T2 actual)
        {
            decoratedTest.runTest(expected, actual);
        }
        public override void populate(string[] values)
        {
            graph = new Graph(values);
            edges = graph.GraphToEdges();
        }
    }
}
