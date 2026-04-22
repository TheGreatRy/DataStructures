using TreeLibrary;

namespace BinarySearchTests
{
    public class BinarySearchTests
    {
        #region Add And Clear
        [Fact]
        public void BinaryTreeAddTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            Assert.Equal(5, tree.Root.Data);
            Assert.Equal(3, tree.Root.Left.Data);
            Assert.Equal(8, tree.Root.Right.Data);
        }
        [Fact]
        public void BinaryTreeAddLeftOnlyTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            Node_BST<int> nextNode = tree.Root;
            for(int i = tree.Count; i > 0; i--)
            {
                Assert.Equal(i, nextNode.Data);
                nextNode = nextNode.Left;
            }
        }
        [Fact]
        public void BinaryTreeAddRightOnlyTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            Node_BST<int> nextNode = tree.Root;
            for( int i = 1; i < tree.Count + 1; i++)
            {
                Assert.Equal(i, nextNode.Data);
                nextNode = nextNode.Right;
            }
        }
        [Fact]
        public void BinaryTreeAddCountTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            Assert.Equal(5, tree.Count);
        }
        [Fact]
        public void BinaryTreeAddClearTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Clear();

            Assert.Null(tree.Root);
            Assert.Equal(0, tree.Count);
        }
        [Fact]
        public void BinaryTreeAddClearEmptyTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            
            tree.Clear();

            Assert.Null(tree.Root);
            Assert.Equal(0, tree.Count);
        }
        #endregion

        #region Height
        [Fact]
        public void BinaryTreeHeightCheckBalanced()
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            Assert.Equal(1, tree.Height());
        }
        
        [Fact]
        public void BinaryTreeHeightCheckLeftWeighted()
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            Assert.Equal(4, tree.Height());
        }
        [Fact]
        public void BinaryTreeHeightCheckRightWeighted()
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            Assert.Equal(4, tree.Height());
        }
        [Fact]
        public void BinaryTreeHeightCheckShiftedBalance()
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            Assert.Equal(3, tree.Height());
        }
        #endregion

        #region Contains And Removal
        [Fact]
        public void BinaryTreeContainsPass()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            Assert.True(tree.Contains(6));
        }

        [Fact]
        public void BinaryTreeContainsFail()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            Assert.True(!tree.Contains(2));
        }

        [Fact]
        public void BinaryTreeRemoveRoot()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Remove(5);

            Assert.Equal(3, tree.Root.Data);
            Console.WriteLine("-----Remove Root-----");
            TreePrinter.PrintMyTree(tree);
        }

        [Fact]
        public void BinaryTreeRemoveLeft()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Remove(3);

            Assert.Null(tree.Root.Left);

            Console.WriteLine("-----Remove Left-----");
            TreePrinter.PrintMyTree(tree);
        }
        [Fact]
        public void BinaryTreeRemoveRight()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Remove(8);

            Assert.Null(tree.Root.Right);

            Console.WriteLine("-----Remove Right-----");
            TreePrinter.PrintMyTree(tree);
        }

        [Fact]
        public void BinaryTreeRemoveMiddle()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            Console.WriteLine("-Middle Test: Before Removal-");
            TreePrinter.PrintMyTree(tree);

            tree.Remove(8);

            Console.WriteLine("-Middle Test: After Removal-");
            TreePrinter.PrintMyTree(tree);

            //Assert the removed node was replaced with the correct value
            Assert.Equal(6, tree.Root.Right.Data);
        }

        #endregion

        #region String Traversal and ToArray
        [Fact]
        public void BinaryTreeInOrderSingle()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            string expected = "3, 5, 8";
            string actual = tree.InOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BinaryTreeInOrderLarge()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            string expected = "1, 3, 5, 6, 8, 9, 10";
            string actual = tree.InOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BinaryTreePreOrderSingle()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            string expected = "5, 3, 8";
            string actual = tree.PreOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BinaryTreePreOrderLarge()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            string expected = "5, 3, 1, 8, 6, 9, 10";
            string actual = tree.PreOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BinaryTreePostOrderSingle()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            string expected = "3, 8, 5";
            string actual = tree.PostOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BinaryTreePostOrderLarge()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            string expected = "1, 3, 6, 10, 9, 8, 5";
            string actual = tree.PostOrder();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BinaryTreeToArray()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            int[] expected = { 1, 3, 5, 6, 8, 9, 10 };
            int[] actual = tree.ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BinaryTreeToArrayEmpty()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            Assert.Null(tree.ToArray());
        }
        #endregion
    }
}