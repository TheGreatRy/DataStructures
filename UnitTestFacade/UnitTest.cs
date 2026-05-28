using TreeLibrary;

namespace UnitTestFacade
{
    public class UnitTest 
    {
        protected List<int> insertData = new List<int>();
        public void addData(List<int> data)
        {
            foreach (int num in data)
            {
                insertData.Add(num);
            }
        }
    }

    public class BSTUnitTest  : UnitTest
    {
        public BinarySearchTree<int> tree = new BinarySearchTree<int>();
        public void populateTree()
        {
            if (insertData != null)
            {
                foreach (int num in insertData)
                {
                    tree.Add(num);
                }
            }
        }

    }
    public class AVLUnitTest  : UnitTest
    {
        public AVLTree<int> tree = new AVLTree<int>();
        public void populateTree()
        {
            if (insertData != null)
            {
                foreach (int num in insertData)
                {
                    tree.Add(num);
                }
            }
        }

    }
}
