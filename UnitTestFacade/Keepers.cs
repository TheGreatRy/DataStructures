namespace UnitTestFacade
{
    public class UnitTestKeeper  
    {
        virtual public BSTUnitTest getBSTTests() { return null; }
        virtual public AVLUnitTest getAVLTests() { return null; }

    }

    public class UTKImplementation : UnitTestKeeper 
    {
        public BSTUnitTest getBSTTests()
        {
            BSTUnitTester tester = new BSTUnitTester();
            BSTUnitTest bstTest = (BSTUnitTest) tester.getTests();
            return bstTest;
        }

        public AVLUnitTest getAVLTests()
        {
            AVLUnitTester tester = new AVLUnitTester();
            AVLUnitTest avlTest = (AVLUnitTest)tester.getTests();
            return avlTest;
        }
    }
}
