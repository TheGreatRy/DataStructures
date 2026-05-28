using TreeLibrary;
using Xunit;

namespace UnitTestFacade
{
    public interface Runner
    {
        public UnitTest getTests();
    }

    public class BSTUnitTester : Runner
    {
        public UnitTest getTests()
        {
            BSTUnitTest bstTest = new BSTUnitTest();
            bstTest.addData(new List<int> { 5, 4, 3, 2, 1 });
            bstTest.populateTree();

            Node_BST<int> nextNode = bstTest.tree.Root;
            for (int i = bstTest.tree.Count; i > 0; i--)
            {
                Assert.Equal(i, nextNode.Data);
                nextNode = nextNode.Left;
            }

            return bstTest;
        }
    }

    public class AVLUnitTester : Runner
    {
        public UnitTest getTests()
        {
            AVLUnitTest avlTest = new AVLUnitTest();
            avlTest.addData(new List<int> { 5, 4, 3, 2, 1 });
            avlTest.populateTree();

            TreePrinter.PrintMyTree(avlTest.tree);

            //Root
            Assert.Equal(4, avlTest.tree.Root.Data);
            //Left
            Assert.Equal(2, avlTest.tree.Root.Left.Data);
            Assert.Equal(1, avlTest.tree.Root.Left.Left.Data);
            Assert.Equal(3, avlTest.tree.Root.Left.Right.Data);
            //Right
            Assert.Equal(5, avlTest.tree.Root.Right.Data);


            return avlTest;
        }
    }
}
