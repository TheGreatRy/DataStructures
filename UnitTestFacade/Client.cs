namespace UnitTestFacade
{
    public class Client
    {
        public static void Main(string[] args)
        {
            UnitTestKeeper unitTestKeeper = new UTKImplementation();

            AVLUnitTest avlUnitTest = unitTestKeeper.getAVLTests();
            BSTUnitTest bstUnitTest = unitTestKeeper.getBSTTests();
        }
    }
}
