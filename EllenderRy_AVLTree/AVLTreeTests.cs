using TreeLibrary;

namespace EllenderRy_AVLTree
{
    public class AVLTreeTests
    {

        #region Add And Clear
        [Fact]
        public void AVLTreeAddTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            Assert.Equal(5, tree.Root.Data);
            Assert.Equal(3, tree.Root.Left.Data);
            Assert.Equal(8, tree.Root.Right.Data);
        }
        [Fact]
        public void AVLTreeAddLeftOnlyTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            TreePrinter.PrintMyTree(tree);

            //Root
            Assert.Equal(4, tree.Root.Data);
            //Left
            Assert.Equal(2, tree.Root.Left.Data);
            Assert.Equal(1, tree.Root.Left.Left.Data);
            Assert.Equal(3, tree.Root.Left.Right.Data);
            //Right
            Assert.Equal(5, tree.Root.Right.Data);

        }
        [Fact]
        public void AVLTreeAddRightOnlyTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            TreePrinter.PrintMyTree(tree);

            //Root
            Assert.Equal(2, tree.Root.Data);
            //Left
            Assert.Equal(1, tree.Root.Left.Data);
            //Right
            Assert.Equal(4, tree.Root.Right.Data);
            Assert.Equal(3, tree.Root.Right.Left.Data);
            Assert.Equal(5, tree.Root.Right.Right.Data);
        }
        [Fact]
        public void AVLTreeAddCountTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            Assert.Equal(5, tree.Count);
        }
        [Fact]
        public void AVLTreeAddClearTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Clear();

            Assert.Null(tree.Root);
            Assert.Equal(0, tree.Count);
        }
        [Fact]
        public void AVLTreeAddClearEmptyTest()
        {
            AVLTree<int> tree = new AVLTree<int>();

            tree.Clear();

            Assert.Null(tree.Root);
            Assert.Equal(0, tree.Count);
        }
        #endregion

        #region Height
        [Fact]
        public void AVLTreeHeightCheckBalanced()
        {

            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            Assert.Equal(1, tree.Height());
        }

        [Fact]
        public void AVLTreeHeightCheckLeftWeighted()
        {

            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            Assert.Equal(2, tree.Height());
        }
        [Fact]
        public void AVLTreeHeightCheckRightWeighted()
        {

            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            Assert.Equal(2, tree.Height());
        }
        [Fact]
        public void AVLTreeHeightCheckShiftedBalance()
        {

            AVLTree<int> tree = new AVLTree<int>();
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
        public void AVLTreeContainsPass()
        {
            AVLTree<int> tree = new AVLTree<int>();
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
        public void AVLTreeContainsFail()
        {
            AVLTree<int> tree = new AVLTree<int>();
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
        public void AVLTreeRemoveRoot()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Remove(5);

            Assert.Equal(3, tree.Root.Data);
            Console.WriteLine("-----Remove Root-----");
            TreePrinter.PrintMyTree(tree);
        }

        [Fact]
        public void AVLTreeRemoveLeft()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Remove(3);

            Assert.Null(tree.Root.Left);

            Console.WriteLine("-----Remove Left-----");
            TreePrinter.PrintMyTree(tree);
        }
        [Fact]
        public void AVLTreeRemoveRight()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            tree.Remove(8);

            Assert.Null(tree.Root.Right);

            Console.WriteLine("-----Remove Right-----");
            TreePrinter.PrintMyTree(tree);
        }

        [Fact]
        public void AVLTreeRemoveMiddle()
        {
            AVLTree<int> tree = new AVLTree<int>();
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
            //AND assert rotation worked on removal
            Assert.Equal(9, tree.Root.Right.Data);
            Assert.Equal(6, tree.Root.Right.Left.Data);
            Assert.Equal(10, tree.Root.Right.Right.Data);
        }

        #endregion

        #region String Traversal and ToArray
        [Fact]
        public void AVLTreeInOrderSingle()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            string expected = "3, 5, 8";
            string actual = tree.InOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AVLTreeInOrderLarge()
        {
            AVLTree<int> tree = new AVLTree<int>();
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
        public void AVLTreePreOrderSingle()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            string expected = "5, 3, 8";
            string actual = tree.PreOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AVLTreePreOrderLarge()
        {
            AVLTree<int> tree = new AVLTree<int>();
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
        public void AVLTreePostOrderSingle()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            string expected = "3, 8, 5";
            string actual = tree.PostOrder();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AVLTreePostOrderLarge()
        {
            AVLTree<int> tree = new AVLTree<int>();
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
        public void AVLTreeToArray()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(10);

            int[] expected = { 5, 3, 8, 1, 6, 9, 10 };
            int[] actual = tree.ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AVLTreeToArrayEmpty()
        {
            AVLTree<int> tree = new AVLTree<int>();

            Assert.Null(tree.ToArray());
        }
        #endregion

        #region Rotation Tests
        [Fact]
        public void AVLAddBalanced()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);

            Assert.Equal(5, tree.Root.Data);
            Assert.Equal(3, tree.Root.Left.Data);
            Assert.Equal(8, tree.Root.Right.Data);

            Console.WriteLine("-----Balanced, No Rotation Needed-----");
            TreePrinter.PrintMyTree(tree);
        }

        [Fact]
        public void AVLAddLeftWeighted()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(3);

            Assert.Equal(4, tree.Root.Data);
            Assert.Equal(3, tree.Root.Left.Data);
            Assert.Equal(5, tree.Root.Right.Data);

            Console.WriteLine("-----Left Rotation Needed-----");
            TreePrinter.PrintMyTree(tree);
        }
        [Fact]
        public void AVLAddRightWeighted()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(6);
            tree.Add(7);

            Assert.Equal(6, tree.Root.Data);
            Assert.Equal(5, tree.Root.Left.Data);
            Assert.Equal(7, tree.Root.Right.Data);

            Console.WriteLine("-----Right Rotation Needed-----");
            TreePrinter.PrintMyTree(tree);
        }
        [Fact]
        public void AVLAddLeftRightWeighted()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(10);
            tree.Add(2);
            tree.Add(8);

            Assert.Equal(8, tree.Root.Data);
            Assert.Equal(2, tree.Root.Left.Data);
            Assert.Equal(10, tree.Root.Right.Data);

            Console.WriteLine("-----LeftRight Rotation Needed-----");
            TreePrinter.PrintMyTree(tree);
        }
        [Fact]
        public void AVLAddRightLeftWeighted()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(7);

            Assert.Equal(7, tree.Root.Data);
            Assert.Equal(5, tree.Root.Left.Data);
            Assert.Equal(10, tree.Root.Right.Data);

            Console.WriteLine("-----RightLeft Rotation Needed-----");
            TreePrinter.PrintMyTree(tree);
        }
        #endregion
    }
}