namespace TesterDecorator
{
    public class Main
    {
        public void main(String[] args)
        {
            SLLTestDecorator<int, string> singleListInt = new SLLTestDecorator<int, string>(new Test<int, string>());
            singleListInt.populate(new int[] { 1, 2, 3 });
            singleListInt.runTest("1, 2, 3", singleListInt.singleLinkedList.ToString());

            DLLTestDecorator<char, string> doubleListChar = new DLLTestDecorator<char, string>(new Test<char, string>());
            doubleListChar.populate(new char[] { 'a', 'k', 'w', 'p' });
            doubleListChar.runTest("a, k, w, p", doubleListChar.doubleLinkedList.ToString());

            StackTestDecorator<int, int> stackTest = new StackTestDecorator<int, int>(new Test<int, int>());
            stackTest.populate(new int[] { 1, 2, 3 });
            for (int i = 0; i < stackTest.stack.Count; i++)
            {
                stackTest.runTest(stackTest.stack.Count - i, stackTest.stack.Get(i).Data);
            }

            QueueTestDecorator<int, int> queueTest = new QueueTestDecorator<int, int>(new Test<int, int>());
            queueTest.populate(new int[] { 1, 2, 3 });
            queueTest.runTest(2, queueTest.queue.Peek().Index);

            MSTTestDecorator<string, Graph> mstTest = new MSTTestDecorator<string, Graph>(new Test<string, Graph>());
            mstTest.populate(
                new string[] {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3,F:7",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1,F:4",
                 "F,B:7,D:4,E:4"
                });
            string[] MST = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1",
                 "F,D:4"
            };

            Graph expected = new Graph(MST);

            mstTest.runTest(expected, MinSpanTree.KurskalsAlgo(mstTest.edges));
        }
    }
}
