using StackQueueLibrary;
namespace EllenderRy_StackQueue
{
    public class StackQueueTests
    {
        #region Stack Tests
        [Fact]
        public void PushStackStringTest()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            string expected = "3, 2, 1";
            Assert.Equal(expected, stack.ToString());
        }

        [Fact]
        public void PushStackDataTest()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            for (int i = 0; i < stack.Count; i++)
            {
                Assert.Equal(stack.Count - i, stack.Get(i).Data);
            }

        }
        [Fact]
        public void PeekStackDataTest()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int actual = stack.Peek().Data;

            Assert.Equal(3, actual);

        }
        [Fact]
        public void PeekStackIndexTest()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int actual = stack.Peek().Index;

            Assert.Equal(0, actual);

        }
        [Fact]
        public void PopStackDataTest()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int actual = stack.Pop().Data;
            Assert.Equal(3, actual);
        }
        [Fact]
        public void PopStackStringTest()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            string expected = "2, 1";
            Assert.Equal(expected, stack.ToString());
        }
        [Fact]
        public void ContainsStackTestPass()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            bool actual = stack.Contains(1);
            Assert.True(actual);
        }
        [Fact]
        public void ContainsStackTestFail()
        {
            StackQueueLibrary.Stack<int> stack = new StackQueueLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            bool actual = stack.Contains(4);
            Assert.True(!actual);
        }

        #endregion

        #region Queue Tests
        [Fact]
        public void EnqueueQueueStringTest()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            string expected = "3, 2, 1";
            Assert.Equal(expected, queue.ToString());
        }

        [Fact]
        public void EnqueueQueueDataTest()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            for (int i = 0; i < queue.Count; i++)
            {
                Assert.Equal(queue.Count - i, queue.Get(i).Data);
            }

        }
        [Fact]
        public void PeekQueueDataTest()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int actual = queue.Peek().Data;

            Assert.Equal(1, actual);

        }
        [Fact]
        public void PeekQueueIndexTest()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int actual = queue.Peek().Index;

            Assert.Equal(2, actual);

        }
        [Fact]
        public void DequeueQueueDataTest()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int actual = queue.Dequeue().Data;
            Assert.Equal(1, actual);
        }
        [Fact]
        public void DequeueQueueStringTest()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();

            string expected = "3, 2";
            Assert.Equal(expected, queue.ToString());
        }
        [Fact]
        public void ContainsQueueTestPass()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            bool actual = queue.Contains(1);
            Assert.True(actual);
        }
        [Fact]
        public void ContainsQueueTestFail()
        {
            StackQueueLibrary.Queue<int> queue = new StackQueueLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            bool actual = queue.Contains(4);
            Assert.True(!actual);
        }

        #endregion
    }
}